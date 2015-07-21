using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Crate.Core
{
    public class FileSystem
    {
        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="data">The data.</param>
        public static void Write(string path, List<Instance> data)
        {
            using (var sw = File.CreateText(path))
                sw.Write(JsonConvert.SerializeObject(data));
        }

        /// <summary>
        /// Reads the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static List<Instance> Read(string path)
        {
            if (!File.Exists(path))
                return null;

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<Instance>>(json);
        }
    }
}
