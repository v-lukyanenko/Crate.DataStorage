using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crate.Core.Helpers;
using Crate.Core.Models;
using Crate.Core.Pairs;
using Crate.Core.Repositories;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.DataContext
{
    public class FileContext : IDataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileContext"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="crate"></param>
        public FileContext(string filePath, string crate)
        {
            _filePath = filePath;
            _fileProvider = new FileProvider();
            Pairs = new PairsToFile(filePath, crate);
        }

        /// <summary>
        /// Checks the connection.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool CheckConnection()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The pairs
        /// </summary>
        public IPair Pairs { get; set; }

        #region Public Methods
        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(IRepository repository)
        {
            var instances = GetInstances(repository.Name, typeof(T).Name);
            return instances == null ? null : instances.Select(c => JsonConvert.DeserializeObject<T>(c.Object));
        }

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public IEnumerable<Dictionary<string, object>> Select(string repository, string dataType)
        {
            var instances = GetInstances(repository, dataType);
            return instances == null ? null : instances.Select(c => JsonConvert.DeserializeObject<Dictionary<string, object>>(c.Object));
        }

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public bool SubmitChanges(IRepository repository)
        {
            var names = repository.Data.DistinctBy(c => c.Name);

            foreach (var data in names)
                SubmitChanges(repository, data);

            repository.Data.Clear();

            return true;
        }

        /// <summary>
        /// Clears the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        public void Clear<T>(IRepository repository)
        {
            var type = typeof(T).Name;
            var path = FullPath(repository.Name, type);
            _fileProvider.DeleteFile(path);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void ClearAll()
        {
            _fileProvider.DeleteDirectory(_filePath);
        }

        /// <summary>
        /// Gets all repositories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetRepositories()
        {
            var fullRepPath = _filePath + RepositoriesPath;

            return JsonConvert.DeserializeObject<Dictionary<int, string>>(
                        _fileProvider.Read(fullRepPath)).Select(c => c.Value);
        }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public List<string> GetObjects(string repository)
        {
            var fullRepPath = _filePath + InstanceTypesPath;

            var perositoryId = GetRepositoryId(repository);

            return JsonConvert.DeserializeObject<List<InstanceType>>(
                        _fileProvider.Read(fullRepPath)).Where(c => c.RepositoryId == perositoryId).Select(c => c.Name).ToList();
        }

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public void CreateRepository(string repository)
        {
            _fileProvider.CreateDirectory(_filePath + @"\" + repository);

            var fullRepPath = _filePath + RepositoriesPath;

            var maxId = 0;
            var repositories = new Dictionary<int, string>();

            if (File.Exists(fullRepPath))
            {
                repositories =
                    JsonConvert.DeserializeObject<Dictionary<int, string>>(
                        _fileProvider.Read(fullRepPath));

                maxId = repositories.Keys.Max();
            }

            if (!repositories.ContainsValue(repository))
            {
                repositories.Add(++maxId, repository);
                _fileProvider.Write(fullRepPath, JsonConvert.SerializeObject(repositories));
            }
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="hardSaving"></param>
        /// <param name="repository"></param>
        public void CreateInstance<T>(bool hardSaving, string repository)
        {
            var name = typeof(T).Name;

            var maxId = 0;
            var instanceTypes = new List<InstanceType>();

            var fullRepPath = _filePath + InstanceTypesPath;

            if (File.Exists(fullRepPath))
            {
                instanceTypes =
                    JsonConvert.DeserializeObject<List<InstanceType>>(
                        _fileProvider.Read(fullRepPath));

                maxId = instanceTypes.Max(c => c.Id);
            }

            var repositoryId = GetRepositoryId(repository);

            if (!instanceTypes.Any(c => c.Name == name && c.RepositoryId == repositoryId))
            {
                var typeProperties = typeof(T).GetProperties();
                var properties = typeProperties.ToDictionary(x => x.Name, x => x.PropertyType.Name);

                instanceTypes.Add(new InstanceType()
                {
                    Id = ++maxId,
                    Name = name,
                    Properties = properties,
                    RepositoryId = repositoryId
                });

                _fileProvider.Write(_filePath + InstanceTypesPath, JsonConvert.SerializeObject(instanceTypes));
            }
        }

        /// <summary>
        /// Checks the data types.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool CheckDataTypes(Dictionary<string, string> data, string objectName, string repository)
        {
            var properties = GetObjectStructure(objectName, repository);
            properties.Remove("Id");
            
            return properties.Select(p => Tools.CheckProperyType(data, p)).All(result => result);
        }

        /// <summary>
        /// Gets the object structure.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Dictionary<string, string> GetObjectStructure(string name, string repository)
        {
            var fullRepPath = _filePath + InstanceTypesPath;

            var perositoryId = GetRepositoryId(repository);

            var firstOrDefault = JsonConvert.DeserializeObject<List<InstanceType>>(
                _fileProvider.Read(fullRepPath)).FirstOrDefault(c => c.RepositoryId == perositoryId);

            return firstOrDefault != null ?
                firstOrDefault.Properties : new Dictionary<string, string>();
        }

        #endregion

        #region Private Mathods
        private void SubmitChanges(IRepository repository, Instance data)
        {
            var fullPath = FullPath(repository.Name, data.Name);

            switch (data.Type)
            {
                case OperationType.Saving:
                    Add(repository, data, fullPath);
                    break;
                case OperationType.Updating:
                    Update(data, fullPath);
                    break;
                case OperationType.Removing:
                    Remove(data, fullPath);
                    break;
            }
        }

        private void Add(IRepository repository, Instance data, string path)
        {
            var newData = repository.Data.Where(c => c.Name == data.Name).ToList();
            var instances = FileHelpers.ReadOldDataIfExists(path);

            instances.AddRange(newData);
            var jSonInstances = JsonConvert.SerializeObject(instances);

            _fileProvider.Write(path, jSonInstances);
        }

        private void Update(Instance data, string path)
        {
            var instances = FileHelpers.ReadOldDataIfExists(path);
            var updated = instances.SingleOrDefault(c => c.Id == data.Id);

            if (updated != null)
            {
                updated.Object = data.Object;

                var jSonInstances = JsonConvert.SerializeObject(instances);
                _fileProvider.Write(path, jSonInstances);
            }
        }

        private void Remove(Instance data, string path)
        {
            var instances = FileHelpers.ReadOldDataIfExists(path);
            var removed = instances.SingleOrDefault(c => c.Id == data.Id);

            if (removed != null)
            {
                instances.Remove(removed);

                var jSonInstances = JsonConvert.SerializeObject(instances);
                _fileProvider.Write(path, jSonInstances);
            }
        }

        private string FullPath(string repository, string obj)
        {
            return Path.Combine(_filePath, string.Format(@"{0}\{1}.{2}", repository, obj, Constants.FileExtension));
        }

        private List<Instance> GetInstances(string repository, string dataType)
        {
            var fullPath = FullPath(repository, dataType);
            var jSon = _fileProvider.Read(fullPath);

            return jSon == null ? new List<Instance>() : JsonConvert.DeserializeObject<List<Instance>>(jSon);
        }

        private int GetRepositoryId(string name)
        {
            var fullRepPath = _filePath + RepositoriesPath;

            if (File.Exists(fullRepPath))
            {
                var repositories =
                    JsonConvert.DeserializeObject<Dictionary<int, string>>(
                        _fileProvider.Read(fullRepPath));

                return repositories.SingleOrDefault(c => c.Value == name).Key;
            }
            return 0;
        }
        #endregion

        private readonly string _filePath;
        private readonly FileProvider _fileProvider;

        private const string InstanceTypesPath = @"\_system\_instanceTypes.txt";
        private const string RepositoriesPath = @"\_system\_repositories.txt";
    }
}
