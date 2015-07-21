using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Crate.Core
{
    public class Pair : IPair
    {
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add<T>(string key, T value)
        {
            var instances = Helpers.ReadOldDataIfExists(FullPath).Where(c => c.Name == key);

            if(instances.Any())
                return;

            SerializeAndSubmit(key, value, OperationType.Saving);
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Update<T>(string key, T value)
        {
            SerializeAndSubmit(key, value, OperationType.Updating);
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            SubmitInstance(key, OperationType.Removing);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public T Get<T>(string key) where T : new()
        {
            var instance = Helpers.ReadOldDataIfExists(FullPath).SingleOrDefault(c => c.Name == key);
            return instance == null ? new T() : JsonConvert.DeserializeObject<T>(instance.Object);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string Get(string key)
        {
            var instance = Helpers.ReadOldDataIfExists(FullPath).SingleOrDefault(c => c.Name == key);
            return instance == null ? string.Empty : instance.Object;
        }

        public void ClearAll()
        {
            File.Delete(FullPath);
        }

        private void SubmitInstance(string key, OperationType type, string obj = null)
        {
            var instance = new Instance
            {
                Id = null,
                Name = key,
                Object = obj,
                Type = type
            };

            SubmitChanges(key, instance);
        }

        private void SerializeAndSubmit<T>(string key, T value, OperationType type)
        {
            var serialized = JsonConvert.SerializeObject(value);
            SubmitInstance(key, type, serialized);
        }

        private void SubmitChanges(string name, Instance data)
        {
            switch (data.Type)
            {
                case OperationType.Saving:
                    Add(data, FullPath);
                    break;
                case OperationType.Updating:
                    Update(data, FullPath);
                    break;
                case OperationType.Removing:
                    Remove(name, FullPath);
                    break;
            }
        }

        private static void Add(Instance data, string path)
        {
            var instances = Helpers.ReadOldDataIfExists(path);
            instances.Add(data);
            FileSystem.Write(path, instances);
        }

        private static void Update(Instance data, string path)
        {
            var instances = Helpers.ReadOldDataIfExists(path);
            var updated = instances.SingleOrDefault(c => c.Name == data.Name);

            if (updated != null)
            {
                updated.Object = data.Object;
                FileSystem.Write(path, instances);
            }
        }

        private static void Remove(string key, string path)
        {
            var instances = Helpers.ReadOldDataIfExists(path);
            var removed = instances.SingleOrDefault(c => c.Name == key);

            if (removed != null)
            {
                instances.Remove(removed);
                FileSystem.Write(path, instances);
            }
        }

        

        private static string FullPath
        {
            get
            {
                return Path.Combine(Path.GetTempPath(), string.Format("{0}.{1}", Constants.PairsFileName, Constants.FileExtension));
            }
        }
    }
}
