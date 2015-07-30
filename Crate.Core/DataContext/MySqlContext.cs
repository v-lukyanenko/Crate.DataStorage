using Crate.Core.Pairs;
using Crate.DataAccess;

namespace Crate.Core.DataContext
{
    public class MySqlContext : SqlDataContextBase, IDataContext
    {
        public MySqlContext(string connectionString)
            : base(new MySqlProvider(connectionString))
        {
            Pairs = new PairToMySql(connectionString);
        }

        public IPair Pairs { get; private set; }
    }
}
