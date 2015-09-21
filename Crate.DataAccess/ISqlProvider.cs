using System.Collections.Generic;

namespace Crate.DataAccess
{
    public interface ISqlProvider
    {
        /// <summary>
        /// Selects the specified quert.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="column"></param>
        /// <returns></returns>
        IEnumerable<string> Select(string query, Dictionary<string, string> parameters, string column);

        /// <summary>
        /// Selects the dictionary.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="keyColumn">The key column.</param>
        /// <param name="valueColumn">The value column.</param>
        /// <returns></returns>
        Dictionary<string, string> SelectDictionary(string query, Dictionary<string, string> parameters, 
            string keyColumn, string valueColumn);

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