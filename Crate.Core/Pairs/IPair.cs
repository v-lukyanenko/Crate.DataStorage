
using System.Collections.Generic;

namespace Crate.Core.Pairs
{
    public interface IPair
    {
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Add(string key, string value);

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Update(string key, string value);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>
        /// Ifs the exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        bool IfExists(string key);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, string> GetAll();

        /// <summary>
        /// Gets all from crate.
        /// </summary>
        /// <param name="crate">The crate.</param>
        /// <returns></returns>
        Dictionary<string, string> GetAllFromCrate(string crate);

            /// <summary>
        /// Gets the crates.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetCrates();

        /// <summary>
        /// Clears all.
        /// </summary>
        void ClearAll();
    }
}