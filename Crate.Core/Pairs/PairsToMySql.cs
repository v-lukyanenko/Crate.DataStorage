
using Crate.DataAccess;

namespace Crate.Core.Pairs
{
    public class PairsToMySql : PairsToSqlBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairsToMySql"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public PairsToMySql(string connectionString) :
            base(new MySqlProvider(connectionString))
        {
        }
    }
}