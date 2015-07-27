using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Crate.DataAccess
{
    /// <summary>
    /// Sql Provider
    /// </summary>
    public class SqlProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlProvider"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SqlProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        #region Public Methods
        /// <summary>
        /// Selects the specified quert.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IEnumerable<string> Select(string query, Dictionary<string, string> parameters)
        {
            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, cn))
            {
                AddParameters(cmd, parameters);

                cn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                    yield return reader["Object"].ToString();
            }
        }

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        public void RunQuery(string query, Dictionary<string, string> parameters)
        {
            using (var cn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, cn))
            {
                AddParameters(cmd, parameters);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
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
