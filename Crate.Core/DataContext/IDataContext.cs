using System.Collections.Generic;
using Crate.Core.Pairs;
using Crate.Core.Repositories;

namespace Crate.Core.DataContext
{
    public interface IDataContext
    {
        /// <summary>
        /// The pairs
        /// </summary>
        IPair Pairs { get; }

        /// <summary>
        /// Checks the connection.
        /// </summary>
        /// <returns></returns>
        bool CheckConnection();

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(IRepository repository);

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        IEnumerable<Dictionary<string, object>> Select(string repository, string dataType);

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="repository">The repository.</param>
        void SubmitChanges(IRepository repository);

        /// <summary>
        /// Clears the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        void Clear<T>(IRepository repository);

        /// <summary>
        /// Clears all.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Gets all repositories.
        /// </summary>
        /// <returns></returns>
        List<string> GetRepositories();

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        List<string> GetObjects(string repository);
    }
}