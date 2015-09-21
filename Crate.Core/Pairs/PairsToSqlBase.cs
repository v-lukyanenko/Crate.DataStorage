using System.Collections.Generic;
using System.Linq;
using Crate.DataAccess;

namespace Crate.Core.Pairs
{
    public class PairsToSqlBase : IPair
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairsToSqlBase"/> class.
        /// </summary>
        /// <param name="sqlDataAccess">The SQL data access.</param>
        /// <param name="crate"></param>
        public PairsToSqlBase(ISqlProvider sqlDataAccess, string crate)
        {
            _sqlDataAccess = sqlDataAccess;
            _crate = crate;
        }

        #region Public Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            if (IfExists(key))
                return;

            var parameters = AddParameters(key, value);

            _sqlDataAccess.RunQuery(InsertQuery, parameters);
        }

        public bool IfExists(string key)
        {
            var ifExistsParams = new Dictionary<string, string> { { KeySql, key } };

            return _sqlDataAccess.IfExists(IfExistsQuery, ifExistsParams);
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Update(string key, string value)
        {
            var parameters = AddParameters(key, value);
            _sqlDataAccess.RunQuery(UpdateQuery, parameters);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            var parameters = new Dictionary<string, string>
            {
                {KeySql, key}
            };

            _sqlDataAccess.RunQuery(DeleteQuery, parameters);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string Get(string key)
        {
            var parameters = AddParameters(key, null);
            return _sqlDataAccess.Select(SelectQuery, parameters, "Object").FirstOrDefault();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAll()
        {
            return _sqlDataAccess.SelectDictionary(SelectAllQuery, null, "UniqueKey", "Object");
        }

        public Dictionary<string, string> GetAllFromCrate(string crate)
        {
            var parameters = new Dictionary<string, string> { { CrateSql, crate } };

            return _sqlDataAccess.SelectDictionary(SelectAllFromCrateQuery, parameters, "UniqueKey", "Object");
        }

        /// <summary>
        /// Gets the crates.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCrates()
        {
            return _sqlDataAccess.Select(GetCratesQuery, null, "Crate");
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            _sqlDataAccess.RunQuery(ClearAllQuery, null);
        }
        #endregion

        private Dictionary<string, string> AddParameters(string key, string value)
        {
            var parameters = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(key))
                parameters.Add(KeySql, key);

            if (!string.IsNullOrWhiteSpace(value))
                parameters.Add(ValueSql, value);

            parameters.Add(CrateSql, _crate);

            return parameters;
        }
        private const string KeySql = "@Key";
        private const string ValueSql = "@Object";
        private const string CrateSql = "@Crate";

        private readonly ISqlProvider _sqlDataAccess;
        private readonly string _crate;

        #region Queries
        private const string SelectQuery = "SELECT * FROM Pairs WHERE UniqueKey = @Key";
        private const string SelectAllQuery = "SELECT * FROM Pairs";
        private const string SelectAllFromCrateQuery = "SELECT * FROM Pairs where Crate = @Crate";
        private const string InsertQuery = "INSERT INTO Pairs (UniqueKey, Object, Crate) VALUES (@Key, @Object, @Crate)";
        private const string UpdateQuery = "UPDATE Pairs SET Object = @Object WHERE UniqueKey = @Key";
        private const string DeleteQuery = "Delete from Pairs WHERE UniqueKey = @Key";
        private const string ClearAllQuery = "Delete from Pairs";
        private const string IfExistsQuery = "SELECT * FROM Pairs WHERE UniqueKey = @Key";
        private const string GetCratesQuery = "SELECT Crate FROM Pairs Group By Crate";
        #endregion
    }
}
