using System.Collections.Generic;
using System.Linq;
using Crate.Core.Models;
using Crate.Core.Pairs;
using Crate.Core.Repositories;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.DataContext
{
    public class SqlDataContextBase
    {
        /// <summary>
        /// Gets or sets the pairs.
        /// </summary>
        /// <value>
        /// The pairs.
        /// </value>
        public IPair Pairs { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataContextBase"/> class.
        /// </summary>
        /// <param name="sqlDataAccess">The SQL data access.</param>
        public SqlDataContextBase(ISqlProvider sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        #region Public Methods

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(IRepository repository)
        {
            var data = GetData(repository.Name, typeof(T).Name);
            return data.Select(JsonConvert.DeserializeObject<T>).ToList();
        }

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        public IEnumerable<Dictionary<string, object>> Select(string repository, string dataType)
        {
            var data = GetData(repository, dataType);
            return data.Select(JsonConvert.DeserializeObject<Dictionary<string, object>>).ToList();
        }

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public bool SubmitChanges(IRepository repository)
        {
            var names = repository.Data.ToList();
            var repositoryId = GetRepositoryId(repository.Name);

            if (repositoryId == null)
                return false;

            foreach (var data in names)
                SubmitChanges(repository, data, repositoryId);

            repository.Data.Clear();

            return true;
        }

        /// <summary>
        /// Checks the data types.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public bool CheckDataTypes(Dictionary<string, string> data, string objectName, string repository)
        {
            var properties = GetObjectStructure(objectName, repository);
            properties.Remove("Id");

            return properties.Select(p => Tools.CheckProperyType(data, p)).All(result => result);
        }

        /// <summary>
        /// Clears the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        public void Clear<T>(IRepository repository)
        {
            var id = GetRepositoryId(repository.Name);

            if (id == null)
                return;

            var parameters = new Dictionary<string, string>
            {
                {RepositoryIdSql, id}
            };

            _sqlDataAccess.RunQuery(Queries.ClearInstances, parameters);
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            _sqlDataAccess.RunQuery(Queries.ClearAllInstances, null);
        }

        /// <summary>
        /// Gets all repositories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetRepositories()
        {
            return _sqlDataAccess.Select(Queries.GetRepositories, null, "Name");
        }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <returns></returns>
        public List<string> GetObjects(string repository)
        {
            var repositoryId = GetRepositoryId(repository);
            var parameters = new Dictionary<string, string>
            {
                {RepositoryIdSql, repositoryId}
            };
            return _sqlDataAccess.Select(Queries.GetObjects, parameters, "Name").ToList();
        }

        public Dictionary<string, string> GetObjectStructure(string name, string repository)
        {
            var repositoryId = GetRepositoryId(repository);

            var parameters = new Dictionary<string, string>
            {
                {ObjectNameSql, name},
                {RepositoryIdSql, repositoryId}
            };

            var queryResult = _sqlDataAccess.Select(Queries.SelectProperties, parameters, "Properties").SingleOrDefault();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(queryResult);
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void CreateInstance<T>(bool hardSaving, string repository)
        {
            var name = typeof(T).Name;

            var typeProperties = typeof(T).GetProperties();
            var properties = typeProperties.ToDictionary(x => x.Name, x => x.PropertyType.Name);

            var repositoryId = GetRepositoryId(repository);

            if (IsInstanceExists(name, repositoryId))
            {
                if (hardSaving)
                    UpdateInstance(name, repositoryId, properties);
            }
            else
                SaveInstance(name, repositoryId, properties);
        }

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public void CreateRepository(string repository)
        {
            var isExists = IsRepositoryExists(repository);

            if (!isExists)
                AddRepository(repository);
        }

        #endregion Public Methods

        #region Private Methods
        private void SubmitChanges(IRepository repository, Instance data, string repositoryId)
        {
            switch (data.Type)
            {
                case OperationType.Saving:
                    Add(repository, data, repositoryId);
                    break;
                case OperationType.Updating:
                    Update(repository, data, repositoryId);
                    break;
                case OperationType.Removing:
                    Remove(repository, data, repositoryId);
                    break;
            }
        }

        private void Add(IRepository repository, Instance data, string repositoryId)
        {
            var objectId = GetInstanceTypeId(data.Name, repositoryId);

            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {NameSql, data.Name},
                {ObjectIdSql, objectId},
                {ObjectSql, data.Object},
                {RepositoryIdSql, repositoryId}
            };

            _sqlDataAccess.RunQuery(Queries.InsertToInstance, parameters);
        }

        private void Update(IRepository repository, Instance data, string repositoryId)
        {
            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {ObjectSql, data.Object},
                {RepositoryIdSql, repositoryId}
            };

            _sqlDataAccess.RunQuery(Queries.UpdateInstance, parameters);
        }

        private void Remove(IRepository repository, Instance data, string repositoryId)
        {
            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {RepositoryIdSql, repositoryId}
            };

            _sqlDataAccess.RunQuery(Queries.DeleteInstance, parameters);
        }

        private IEnumerable<string> GetData(string repository, string dataType)
        {
            var repositoryId = GetRepositoryId(repository);

            var objectId = GetInstanceTypeId(dataType, repositoryId);

            var parameters = new Dictionary<string, string>
            {
                {ObjectIdSql, objectId},
                {RepositoryIdSql, repositoryId}
            };

            return _sqlDataAccess.Select(Queries.SelectInstances, parameters, "ObjectData");
        }

        private bool IsInstanceExists(string name, string repositoryId)
        {
            var parameters = new Dictionary<string, string>
            {
                {RepositoryIdSql, repositoryId},
                {NameSql, name}
            };

            return _sqlDataAccess.Select(Queries.IsInstanceExists, parameters, Id).Any();
        }

        private bool IsRepositoryExists(string name)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, name}
            };

            return _sqlDataAccess.Select(Queries.IsRepositoryExists, parameters, Id).Any();
        }

        private void AddRepository(string name)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, name}
            };

            _sqlDataAccess.RunQuery(Queries.InsertNewRepository, parameters);
        }

        private string GetRepositoryId(string name)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, name}
            };

            return _sqlDataAccess.Select(Queries.SelectRepositoryId, parameters, Id).SingleOrDefault();
        }

        private void SaveInstance(string name, string repositoryId, Dictionary<string, string> properties)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, name},
                {PropertiesSql, JsonConvert.SerializeObject(properties)},
                {RepositoryIdSql, repositoryId}

            };

            _sqlDataAccess.RunQuery(Queries.InsertNewInstance, parameters);
        }

        private void UpdateInstance(string name, string repositoryId, Dictionary<string, string> properties)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, name},
                {RepositorySql, repositoryId},
                {PropertiesSql, JsonConvert.SerializeObject(properties)}
            };

            _sqlDataAccess.RunQuery(Queries.UpdateInstanceType, parameters);
        }

        private string GetInstanceTypeId(string objectName, string repositoryId)
        {
            var objIdParams = new Dictionary<string, string>
            {
                {NameSql, objectName},
                {RepositoryIdSql, repositoryId}
            };

            return _sqlDataAccess.Select(Queries.SelectInstTypeId, objIdParams, "Id").SingleOrDefault();
        }

        //***************************************
        #endregion

        private const string NameSql = "@Name";
        private const string GuidIdSql = "@GuidID";
        private const string ObjectSql = "@Object";
        private const string RepositorySql = "@Repository";
        private const string PropertiesSql = "@Properties";
        private const string ObjectIdSql = "@ObjectId";
        private const string ObjectNameSql = "@ObjectName";
        private const string RepositoryIdSql = "@RepositoryId";
        private const string Id = "Id";

        private readonly ISqlProvider _sqlDataAccess;
    }
}
