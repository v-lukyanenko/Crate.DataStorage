using System.Collections.Generic;

namespace Crate.Core
{
    public interface IDataContext
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        List<Instance> Data { get; }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Select<T>(Storage storage);

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="storage">The storage.</param>
        void SubmitChanges(Storage storage);
    }
}