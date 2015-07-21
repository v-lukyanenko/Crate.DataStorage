using System.Collections.Generic;

namespace Crate.Core
{
    public interface IStorage
    {
        List<Instance> Data { get; set; }

        string Name { get; set; }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Add<T>(T t);

        /// <summary>
        /// Updates the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Update<T>(T t);

        /// <summary>
        /// Removes the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Remove<T>(T t);

        /// <summary>
        /// Undoes the pending changes.
        /// </summary>
        void UndoPendingChanges();
    }
}