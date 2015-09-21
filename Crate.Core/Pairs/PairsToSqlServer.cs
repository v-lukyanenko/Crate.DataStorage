using Crate.DataAccess;

namespace Crate.Core.Pairs
{
    /// <summary>
    /// Writes Pairs to Sql
    /// </summary>
    public class PairsToSqlServer : PairsToSqlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairsToSqlServer"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="crate"></param>
        public PairsToSqlServer(string connectionString, string crate) :
            base(new SqlServerProvider(connectionString), crate)
        {
        }
    }
}
