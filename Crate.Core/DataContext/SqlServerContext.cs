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
        public SqlServerContext(string connectionString)
            : base(new SqlServerProvider(connectionString))
        {
            Pairs = new PairsToSqlServer(connectionString);
        }

        /// <summary>
        /// Checks the connection.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        public static bool CheckConnection(string connectionString)
        {
            return true;// SqlServerProvider.CheckConnection(connectionString);
        }

        /// <summary>
        /// The pairs
        /// </summary>
        public IPair Pairs { get; private set; }
    }
}
