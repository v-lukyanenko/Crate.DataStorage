using System;
using System.Collections.Generic;
using Crate.Core.Models;

namespace Crate.Core.Repositories
{
    public interface IRepository
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        List<Instance> Data { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
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
        /// Updates the specified json.
        /// </summary>
        /// <param name="data"></param>
        void UpdateFromDictionary(IReadOnlyDictionary<string, string> data);

        /// <summary>
        /// Removes the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Remove<T>(T t);

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Remove(Guid id);

        /// <summary>
        /// Undoes the pending changes.
        /// </summary>
        void UndoPendingChanges();
    }
}