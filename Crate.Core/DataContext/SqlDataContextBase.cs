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
        public SqlDataContextBase(ISqlProvider sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        #region Public Methods

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

        public void SubmitChanges(IRepository repository)
        {
            var names = repository.Data.DistinctBy(c => c.Name).ToList();

            foreach (var data in names)
                SubmitChanges(repository, data);

            repository.Data.Clear();
        }

        public void Clear<T>(IRepository repository)
        {
            var parameters = new Dictionary<string, string>
            {
                {RepositorySql, repository.Name}
            };

            _sqlDataAccess.RunQuery(ClearQuery, parameters);
        }

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
        protected const string SelectQuery = "SELECT * FROM instance WHERE Name = @Name and Repository = @Repository";
        protected const string InsertQuery = "INSERT INTO instance (GuidID, Name, Object, Repository) " +
                                             "VALUES (@GuidID, @Name, @Object, @Repository)";
        protected const string UpdateQuery = "UPDATE Instance SET Object = @Object WHERE GuidID = @GuidID AND Repository = @Repository";
        protected const string DeleteQuery = "Delete from Instance WHERE GuidID = @GuidID AND Repository = @Repository";
        protected const string ClearQuery = "Delete from Instance WHERE Repository = @Repository";
        protected const string ClearAllQuery = "Delete from Instance";
        #endregion

        protected const string NameSql = "@Name";
        protected const string GuidIdSql = "@GuidID";
        protected const string ObjectSql = "@Object";
        protected const string RepositorySql = "@Repository";

        private readonly ISqlProvider _sqlDataAccess;
        
    }
}
