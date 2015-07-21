using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Crate.Core
{
    public class DataContext : IDataContext
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Instance> Data { get; private set; }

        /// <summary>
        /// The pairs
        /// </summary>
        public static IPair Pairs = new Pair();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public DataContext(string filePath)
        {
            Data = new List<Instance>();
            _filePath = filePath;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Select<T>(Storage storage)
        {
            var fullPath = FullPath(storage.Name, typeof(T).Name);
            var instances = FileSystem.Read(fullPath);

            return instances == null ? null : instances.Select(c => JsonConvert.DeserializeObject<T>(c.Object));
        }

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="storage">The storage.</param>
        public void SubmitChanges(Storage storage)
        {
            var names = storage.Data.DistinctBy(c => c.Name);

            foreach (var data in names)
                SubmitChanges(storage, data);

            storage.Data.Clear();
        }

        private void SubmitChanges(IStorage storage, Instance data)
        {
            var fullPath = FullPath(storage.Name, data.Name);
            var directory = Path.GetDirectoryName(fullPath);
            
            Directory.CreateDirectory(directory);

            switch (data.Type)
            {
                case OperationType.Saving:
                    Add(storage, data, fullPath);
                    break;
                case OperationType.Updating:
                    Update(data, fullPath);
                    break;
                case OperationType.Removing:
                    Remove(data, fullPath);
                    break;
            }
        }

        private static void Add(IStorage storage, Instance data, string path)
        {
            var newData = storage.Data.Where(c => c.Name == data.Name).ToList();
            var instances = Helpers.ReadOldDataIfExists(path);
            instances.AddRange(newData);
            FileSystem.Write(path, instances);
        }

        private static void Update(Instance data, string path)
        {
            var instances = Helpers.ReadOldDataIfExists(path);
            var updated = instances.SingleOrDefault(c => c.Id == data.Id);

            if (updated != null)
            {
                updated.Object = data.Object;
                FileSystem.Write(path, instances);
            }
        }

        private static void Remove(Instance data, string path)
        {
            var instances = Helpers.ReadOldDataIfExists(path);
            var removed = instances.SingleOrDefault(c => c.Id == data.Id);

            if (removed != null)
            {
                instances.Remove(removed);
                FileSystem.Write(path, instances);
            }
        }

        private string FullPath(string storage, string obj)
        {
            return Path.Combine(_filePath, string.Format(@"{0}\{1}.{2}", storage, obj, Constants.FileExtension));
        }

        private readonly string _filePath;
    }
}
