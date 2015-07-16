
namespace Crate.Core
{
    public interface IFileSystem
    {
        /// <summary>
        /// Reads the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        string Read(string name);

        /// <summary>
        /// Saves the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="name">The name.</param>
        void Write(string data, string name);

        /// <summary>
        /// Deletes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        bool Delete(string name);

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns></returns>
        string[] GetFiles();
    }
}
