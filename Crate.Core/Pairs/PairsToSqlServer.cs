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
        public PairsToSqlServer(string connectionString) :
            base(new SqlServerProvider(connectionString))
        {
        }
    }
}
