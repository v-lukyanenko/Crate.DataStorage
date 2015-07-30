using Crate.Core.Pairs;
using Crate.DataAccess;

namespace Crate.Core.DataContext
{
    public class SqlServerContext : SqlDataContextBase, IDataContext
    {
        public SqlServerContext(string connectionString)
            : base(new SqlServerProvider(connectionString))
        {
            Pairs = new PairToSqlServer(connectionString);
        }

        public IPair Pairs { get; private set; }
    }
}
