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
        public PairsToFile(string path, string crate)
        {
            _fileProvider = new FileProvider();
            _path = path;
            _crate = crate;
        }

        #region Public Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, string value)
        {
            var instances = FileHelpers.ReadOldDataIfExists(FullPath).Where(c => c.Name == key);
            if (instances.Any())
                return;

            SubmitInstance(key, OperationType.Saving, value);
        }

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Update(string key, string value)
        {
            SubmitInstance(key, OperationType.Updating, value);
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
        /// Ifs the exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IfExists(string key)
        {
            return FileHelpers.ReadOldDataIfExists(FullPath).Any(c => c.Name == key);
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
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetAll()
        {
            return FileHelpers.ReadOldDataIfExists(FullPath).ToDictionary(c=>c.Name, c=>c.Object);
        }

        /// <summary>
        /// Gets the crates.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCrates()
        {
            return FileHelpers.ReadOldDataIfExists(FullPath).GroupBy(c=>c.Repository).Select(c=>c.Key);
        }

        /// <summary>
        /// Gets all from crate.
        /// </summary>
        /// <param name="crate">The crate.</param>
        /// <returns></returns>
        public Dictionary<string, string> GetAllFromCrate(string crate)
        {
            return FileHelpers.ReadOldDataIfExists(FullPath).Where(c=>c.Repository == crate).ToDictionary(c => c.Name, c => c.Object);
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
                Type = type,
                Repository = _crate
            };

            SubmitChanges(key, instance);
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
        private readonly string _crate;
    }
}
