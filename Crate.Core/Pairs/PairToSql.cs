using System.Collections.Generic;
using System.Linq;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.Pairs
{
    /// <summary>
    /// Writes Pairs to Sql
    /// </summary>
    public class PairToSql : IPair
    {
        public PairToSql(string connectionString)
        {
            _sqlDataAccess = new SqlProvider(connectionString);
        }

        #region Public Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add<T>(string key, T value)
        {
            var ifExistsParams = new Dictionary<string, string> { { KeySql, key } };

            if (_sqlDataAccess.IfExists(IfExistsQuery, ifExistsParams))
                return;

            var parameters = AddParameters(key, JsonConvert.SerializeObject(value));

            _sqlDataAccess.RunQuery(InsertQuery, parameters);
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Update<T>(string key, T value)
        {
            var parameters = AddParameters(key, JsonConvert.SerializeObject(value));
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
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : new()
        {
            var data = Get(key);
            return JsonConvert.DeserializeObject<T>(data);
        }

        public string Get(string key)
        {
            var parameters = AddParameters(key, null);
            return _sqlDataAccess.Select(SelectQuery, parameters).FirstOrDefault();
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            _sqlDataAccess.RunQuery(ClearAllQuery, null);
        }
        #endregion

        private static Dictionary<string, string> AddParameters(string key, string value)
        {
            var parameters = new Dictionary<string, string>();

            if(!string.IsNullOrWhiteSpace(key))
                parameters.Add(KeySql, key);

            if (!string.IsNullOrWhiteSpace(value))
                parameters.Add(ValueSql, value);

            return parameters;
        }

        #region Queries
        private const string SelectQuery = "SELECT * FROM dbo.Pairs WHERE [Key] = @Key";

        private const string InsertQuery = "INSERT INTO dbo.Pairs ([Key], Object) VALUES (@Key, @Object)";

        private const string UpdateQuery = "UPDATE dbo.Pairs SET Object = @Object WHERE [Key] = @Key";

        private const string DeleteQuery = "Delete from dbo.Pairs WHERE [Key] = @Key";

        private const string ClearAllQuery = "Delete from dbo.Pairs";

        private const string IfExistsQuery = "SELECT * FROM dbo.Pairs WHERE [Key] = @Key";
        #endregion

        private const string KeySql = "@Key";
        private const string ValueSql = "@Object";

        private readonly SqlProvider _sqlDataAccess;
    }
}
