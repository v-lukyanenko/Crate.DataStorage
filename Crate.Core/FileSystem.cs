using System.IO;
using System.Xml.Linq;
using Crate.Core;

namespace Crate.Core
{
    public class FileSystem : IFileSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystem"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public FileSystem(string filePath)
        {
            _filePath = filePath;
            Directory.CreateDirectory(_filePath);
        }

        /// <summary>
        /// Reads the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public string Read(string name)
        {
            if (!name.Contains(Constants.FileExtension))
                name += Constants.FileExtension;

            var fullPath = _filePath + name;
            return !File.Exists(fullPath) ? string.Empty : XDocument.Parse(File.ReadAllText(fullPath)).ToString();
        }

        /// <summary>
        /// Saves the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="name">The name.</param>
        public void Write(string data, string name)
        {
            File.WriteAllText(FullName(name), data);
        }

        /// <summary>
        /// Deletes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool Delete(string name)
        {
            var fileName = FullName(name);
            File.Delete(fileName);
            return !File.Exists(FullName(name));
        }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <returns></returns>
        public string[] GetFiles()
        {
            return Directory.GetFiles(_filePath);
        }

        private string FullName(string name)
        {
            return string.Format("{0}{1}{2}", _filePath, name, Constants.FileExtension);
        }

        private readonly string _filePath;
    }
}
