using System.IO;

namespace Crate.DataAccess
{
    public class FileProvider
    {
        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="data">The data.</param>
        public void Write(string path, string data)
        {
            using (var sw = File.CreateText(path))
                sw.Write(data);
        }

        /// <summary>
        /// Reads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public string Read(string path)
        {
            if (!File.Exists(path))
                return null;

            var json = File.ReadAllText(path);
            return json;
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="path">The path.</param>
        public void DeleteFile(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <param name="path">The path.</param>
        public void DeleteDirectory(string path)
        {
            Directory.Delete(path, true);
        }
    }
}
