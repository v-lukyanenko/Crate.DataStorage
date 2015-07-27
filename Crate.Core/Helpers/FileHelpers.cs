using System.Collections.Generic;
using System.IO;
using Crate.Core.Models;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.Helpers
{
    public static class FileHelpers
    {
        /// <summary>
        /// Reads the old data if exists.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static List<Instance> ReadOldDataIfExists(string path)
        {
            var fileProvider = new FileProvider();
            var result = new List<Instance>();

            if (IsFileExists(path))
            {
                var jSon = fileProvider.Read(path);
                result = JsonConvert.DeserializeObject<List<Instance>>(jSon);
            }

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
