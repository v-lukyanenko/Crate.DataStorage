using System.Collections.Generic;
using System.Linq;
using Crate.Core.Models;
using Crate.Core.Repositories;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.DataContext
{
    public class SqlDataContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlDataContextBase"/> class.
        /// </summary>
        /// <param name="sqlDataAccess">The SQL data access.</param>
        public SqlDataContextBase(ISqlProvider sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        #region Public Methods

        public bool CheckConnection()
        {
            return _sqlDataAccess.CheckConnection();
        }

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
        public void SubmitChanges(IRepository repository)
        {
            var names = repository.Data.ToList();

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
            var parameters = new Dictionary<string, string>
            {
                {RepositorySql, repository.Name}
            };

            _sqlDataAccess.RunQuery(ClearQuery, parameters);
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            _sqlDataAccess.RunQuery(ClearAllQuery, null);
        }

        /// <summary>
        /// Gets all repositories.
        /// </summary>
        /// <returns></returns>
        public List<string> GetRepositories()
        {
            var repositories = _sqlDataAccess.Select(GetRepositoriesQuery, null, "Repository");
            return repositories == null ? null : repositories.ToList();
        }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <returns></returns>
        public List<string> GetObjects(string repository)
        {
            var parameters = new Dictionary<string, string>
            {
                {RepositorySql, repository}
            };
            return _sqlDataAccess.Select(GetObjectsQuery, parameters, "Name").ToList();
        }

        #endregion Public Methods

        #region Private Methods
        private void SubmitChanges(IRepository repository, Instance data)
        {
            switch (data.Type)
            {
                case OperationType.Saving:
                    Add(repository, data);
                    break;
                case OperationType.Updating:
                    Update(repository, data);
                    break;
                case OperationType.Removing:
                    Remove(repository, data);
                    break;
            }
        }

        private void Add(IRepository repository, Instance data)
        {
            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {NameSql, data.Name},
                {ObjectSql, data.Object},
                {RepositorySql, repository.Name}
            };

            _sqlDataAccess.RunQuery(InsertQuery, parameters);
        }

        private void Update(IRepository repository, Instance data)
        {
            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {ObjectSql, data.Object},
                {RepositorySql, repository.Name}
            };

            _sqlDataAccess.RunQuery(UpdateQuery, parameters);
        }

        private void Remove(IRepository repository, Instance data)
        {
            var parameters = new Dictionary<string, string>
            {
                {GuidIdSql, data.Id.ToString()},
                {RepositorySql, repository.Name}
            };

            _sqlDataAccess.RunQuery(DeleteQuery, parameters);
        }

        private IEnumerable<string> GetData(string repository, string dataType)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, dataType},
                {RepositorySql, repository}
            };

            return _sqlDataAccess.Select(SelectQuery, parameters, "Object");
        }
        #endregion

        #region Queries
        private const string SelectQuery = "SELECT * FROM instance WHERE Name = @Name and Repository = @Repository";
        private const string InsertQuery = "INSERT INTO instance (GuidID, Name, Object, Repository) " +
                                             "VALUES (@GuidID, @Name, @Object, @Repository)";
        private const string UpdateQuery = "UPDATE Instance SET Object = @Object WHERE GuidID = @GuidID AND Repository = @Repository";
        private const string DeleteQuery = "Delete from Instance WHERE GuidID = @GuidID AND Repository = @Repository";
        private const string ClearQuery = "Delete from Instance WHERE Repository = @Repository";
        private const string ClearAllQuery = "Delete from Instance";
        private const string GetRepositoriesQuery = "SELECT Repository FROM Instance Group By Repository";
        private const string GetObjectsQuery = "SELECT Name FROM Instance Where Repository = @Repository Group By Name";
        #endregion

        private const string NameSql = "@Name";
        private const string GuidIdSql = "@GuidID";
        private const string ObjectSql = "@Object";
        private const string RepositorySql = "@Repository";

        private readonly ISqlProvider _sqlDataAccess;
    }
}
