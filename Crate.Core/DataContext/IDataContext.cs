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
        /// Selects the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(IRepository repository);

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
    }
}