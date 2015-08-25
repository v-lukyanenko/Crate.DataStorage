using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crate.Core.Helpers;
using Crate.Core.Models;
using Crate.DataAccess;
using Newtonsoft.Json;

namespace Crate.Core.Pairs
{
    /// <summary>
    /// Saves Pair to File
    /// </summary>
    public class PairsToFile : IPair
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PairsToFile"/> class.
        /// </summary>
        public PairsToFile(string path)
        {
            _fileProvider = new FileProvider();
            _path = path;
        }

        #region Public Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add<T>(string key, T value)
        {
            var instances = FileHelpers.ReadOldDataIfExists(FullPath).Where(c => c.Name == key);

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
            var instance = FileHelpers.ReadOldDataIfExists(FullPath).SingleOrDefault(c => c.Name == key);
            return instance == null ? new T() : JsonConvert.DeserializeObject<T>(instance.Object);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string Get(string key)
        {
            var instance = FileHelpers.ReadOldDataIfExists(FullPath).SingleOrDefault(c => c.Name == key);
            return instance == null ? string.Empty : instance.Object;
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            _fileProvider.DeleteFile(FullPath);
        }
        #endregion

        #region Private Methods
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

        private void Add(Instance data, string path)
        {
            var instances = FileHelpers.ReadOldDataIfExists(path);
            instances.Add(data);
            SerializeAndWrite(instances, path);
        }

        private void Update(Instance data, string path)
        {
            var instances = FileHelpers.ReadOldDataIfExists(path);
            var updated = instances.SingleOrDefault(c => c.Name == data.Name);

            if (updated != null)
            {
                updated.Object = data.Object;
                SerializeAndWrite(instances, path);
            }
        }

        private void Remove(string key, string path)
        {
            var instances = FileHelpers.ReadOldDataIfExists(path);
            var removed = instances.SingleOrDefault(c => c.Name == key);

            if (removed != null)
            {
                instances.Remove(removed);
                SerializeAndWrite(instances, path);
            }
        }

        private void SerializeAndWrite(List<Instance> instances, string path)
        {
            var jSon = JsonConvert.SerializeObject(instances);
            _fileProvider.Write(path, jSon);
        }
        #endregion

        private string FullPath
        {
            get
            {
                return Path.Combine(_path, string.Format("{0}.{1}", Constants.PairsFileName, Constants.FileExtension));
            }
        }

        private readonly FileProvider _fileProvider;
        private readonly string _path;
    }
}
