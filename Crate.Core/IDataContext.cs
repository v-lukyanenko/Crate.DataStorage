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
        /// Adds the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void Add<T>(T t);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        void AddRange<T>(List<T> range);

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Get<T>();

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        bool Update<T>(T data);

        /// <summary>
        /// Removes the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        bool Remove<T>(T data);

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        T Get<T>(int id) where T : new();

        /// <summary>
        /// Clears this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        void Clear<T>();

        /// <summary>
        /// Clears all.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Saves the data.
        /// </summary>
        void SubmitChanges();
    }
}
