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
        public IEnumerable<string> Select(string query, Dictionary<string, string> parameters)
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
                            yield return reader["Object"].ToString();
                    }
                }
            }
        }

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
