using Crate.DataAccess;

namespace Crate.Core.Pairs
{
    /// <summary>
    /// Writes Pairs to Sql
    /// </summary>
    public class PairToSqlServer : PairsToSqlBase
    {
        public PairToSqlServer(string connectionString) :
            base(new SqlServerProvider(connectionString))
        {
        }
    }
}
