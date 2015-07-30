
using Crate.DataAccess;

namespace Crate.Core.Pairs
{
    public class PairToMySql : PairsToSqlBase
    {
        public PairToMySql(string connectionString) :
            base(new MySqlProvider(connectionString))
        {
        }
    }
}