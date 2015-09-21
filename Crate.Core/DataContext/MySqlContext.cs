using Crate.Core.Pairs;
using Crate.DataAccess;

namespace Crate.Core.DataContext
{
    public class MySqlContext : SqlDataContextBase, IDataContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MySqlContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="crate"></param>
        public MySqlContext(string connectionString, string crate)
            : base(new MySqlProvider(connectionString))
        {
            Pairs = new PairsToMySql(connectionString, crate);
        }
    }
}
