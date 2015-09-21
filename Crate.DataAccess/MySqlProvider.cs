using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Crate.DataAccess
{
    public class MySqlProvider : ISqlProvider
    {
        public MySqlProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Public Methods

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
        /// Selects the specified quert.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="column"></param>
        /// <returns></returns>
        public IEnumerable<string> Select(string query, Dictionary<string, string> parameters, string column)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    AddParameters(cmd, parameters);
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                            yield return reader[column].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Selects the dictionary.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="keyColumn">The key column.</param>
        /// <param name="valueColumn">The value column.</param>
        /// <returns></returns>
        public Dictionary<string, string> SelectDictionary(string query, Dictionary<string, string> parameters,
            string keyColumn, string valueColumn)
        {
            var result = new Dictionary<string, string>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    AddParameters(cmd, parameters);
                    connection.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var key = reader[keyColumn].ToString();
                            var value = reader[valueColumn].ToString();

                            result.Add(key, value);
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        public void RunQuery(string query, Dictionary<string, string> parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                using (var cmd = new MySqlCommand(query, connection))
                {
                    AddParameters(cmd, parameters);
                    connection.Open();
                    cmd.ExecuteReader();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Ifs the exists.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public bool IfExists(string query, Dictionary<string, string> parameters)
        {
            bool result;

            using (var cn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(query, cn))
            {
                AddParameters(cmd, parameters);

                cn.Open();
                result = cmd.ExecuteReader().Read();
                cn.Close();
            }
            return result;
        }
        #endregion

        #region Private Methods
        private static MySqlParameter Create(string key, string value)
        {
            return new MySqlParameter
            {
                ParameterName = key,
                Value = value
            };
        }

        private static void AddParameters(MySqlCommand cmd, Dictionary<string, string> parameters)
        {
            if (parameters == null) return;
            foreach (var param in parameters.Select(p => Create(p.Key, p.Value)))
                cmd.Parameters.Add(param);
        }
        #endregion

        private readonly string _connectionString;
    }
}
