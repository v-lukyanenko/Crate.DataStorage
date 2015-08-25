using System.Collections.Generic;

namespace Crate.DataAccess
{
    public interface ISqlProvider
    {
        /// <summary>
        /// Checks the connection.
        /// </summary>
        /// <returns></returns>
        bool CheckConnection();

        /// <summary>
        /// Selects the specified quert.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="column"></param>
        /// <returns></returns>
        IEnumerable<string> Select(string query, Dictionary<string, string> parameters, string column);

        /// <summary>
        /// Runs the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        void RunQuery(string query, Dictionary<string, string> parameters);

        /// <summary>
        /// Ifs the exists.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        bool IfExists(string query, Dictionary<string, string> parameters);
    }
}