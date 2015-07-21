using System.Collections.Generic;
using System.IO;

namespace Crate.Core
{
    public static class Helpers
    {
        /// <summary>
        /// Reads the old data if exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static List<Instance> ReadOldDataIfExists(string path)
        {
            var result = new List<Instance>();

            if (IsFileExists(path))
                result = FileSystem.Read(path);

            return result;
        }

        /// <summary>
        /// Files the exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private static bool IsFileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
