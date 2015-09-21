using Crate.Core.Pairs;
using Crate.DataAccess;

namespace Crate.Core.DataContext
{
    public class SqlServerContext : SqlDataContextBase, IDataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="crate"></param>
        public SqlServerContext(string connectionString, string crate)
            : base(new SqlServerProvider(connectionString))
        {
            Pairs = new PairsToSqlServer(connectionString, crate);
        }
    }
}
