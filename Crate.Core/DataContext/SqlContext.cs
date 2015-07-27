using System.Collections.Generic;
using System.Linq;
using Crate.Core.Models;
using Crate.Core.Pairs;
using Crate.Core.Repositories;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.DataContext
{
    public class SqlContext : IDataContext
    {
        public SqlContext(string connectionString)
        {
            _sqlDataAccess = new SqlProvider(connectionString);
            Pairs = new PairToSql(connectionString);
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
        /// <param name="repository"></param>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(IRepository repository)
        {
            var parameters = new Dictionary<string, string>
            {
                {NameSql, typeof (T).Name},
                {RepositorySql, repository.Name}
            };

            var data = _sqlDataAccess.Select(SelectQuery, parameters);

            return data.Select(JsonConvert.DeserializeObject<T>).ToList();
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
        /// <exception cref="System.NotImplementedException"></exception>
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
        #endregion

        #region Queries
        private const string SelectQuery = "SELECT * FROM dbo.Instance " +
                                           "WHERE Name = @Name and Repository = @Repository";

        private const string InsertQuery = "INSERT INTO dbo.Instance (GuidID, Name, Object, Repository) " +
                                           "VALUES (@GuidId, @Name, @Object, @Repository)";

        private const string UpdateQuery = "UPDATE dbo.Instance SET Object = @Object " +
                                           "WHERE Id = @Id AND Repository = @Repository";

        private const string DeleteQuery = "Delete from dbo.Instance " +
                                           "WHERE Id = @Id AND Repository = @Repository";

        private const string ClearQuery = "Delete from dbo.Instance " +
                                          "WHERE Repository = @Repository";

        private const string ClearAllQuery = "Delete from dbo.Instance";
        #endregion

        private const string NameSql = "@Name";
        private const string GuidIdSql = "@GuidID";
        private const string ObjectSql = "@Object";
        private const string RepositorySql = "@Repository";

        private readonly SqlProvider _sqlDataAccess;
    }
}
