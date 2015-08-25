using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Crate.DataAccess
{
    /// <summary>
    /// Sql Provider
    /// </summary>
    public class SqlServerProvider : ISqlProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlServerProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Public Methods

        /// <summary>
        /// Determines whether [is server connected].
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    const string query = "select 1";
                    var command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteScalar();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Selects the specified quert.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IEnumerable<string> Select(string query, Dictionary<string, string> parameters, string column)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
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
        /// Runs the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        public void RunQuery(string query, Dictionary<string, string> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
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

            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, cn))
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
        private static SqlParameter Create(string key, string value)
        {
            return new SqlParameter
            {
                ParameterName = key,
                Value = value
            };
        }

        private static void AddParameters(SqlCommand cmd, Dictionary<string, string> parameters)
        {
            if (parameters == null) return;
            foreach (var param in parameters.Select(p => Create(p.Key, p.Value)))
                cmd.Parameters.Add(param);
        }

        #endregion

        private readonly string _connectionString;
    }
}
