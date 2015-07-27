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
        public FileContext(string filePath)
        {
            _filePath = filePath;
            _fileProvider = new FileProvider();
            Pairs = new PairToFile(filePath);
        }

        /// <summary>
        /// The pairs
        /// </summary>
        public IPair Pairs { get; private set; }

        #region Public Methods
        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(IRepository repository)
        {
            var fullPath = FullPath(repository.Name, typeof(T).Name);
            var jSon = _fileProvider.Read(fullPath);

            if (jSon == null)
                return new List<T>();

            var instances = JsonConvert.DeserializeObject<List<Instance>>(jSon);
            return instances == null ? null : instances.Select(c => JsonConvert.DeserializeObject<T>(c.Object));
        }

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public void SubmitChanges(IRepository repository)
        {
            var names = repository.Data.DistinctBy(c => c.Name);

            foreach (var data in names)
                SubmitChanges(repository, data);

            repository.Data.Clear();
        }

        /// <summary>
        /// Clears the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        public void Clear<T>(IRepository repository)
        {
            var type = typeof (T).Name;
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
        #endregion

        #region Private Mathods
        private void SubmitChanges(IRepository repository, Instance data)
        {
            var fullPath = FullPath(repository.Name, data.Name);
            var directory = Path.GetDirectoryName(fullPath);

            if (directory != null) 
                Directory.CreateDirectory(directory);

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
        #endregion

        private readonly string _filePath;
        private readonly FileProvider _fileProvider;
    }
}
