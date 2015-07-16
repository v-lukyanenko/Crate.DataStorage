using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crate.Core;
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
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="numberOfUpdates"></param>
        public DataContext(string filePath, int? numberOfUpdates = null)
        {
            Data = new List<Instance>();
            _filePath = filePath;
            _fileSystem = new FileSystem(_filePath);
            _xmlDataSerializer = new XmlDataSerializer();
            _numberOfUpdates = numberOfUpdates;

            ReadFromFiles();
        }

        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Add<T>(T t)
        {
            var type = typeof(T).Name;
            var maxId = GetMaxId(type);

            AddInstance(t, maxId, type);
            SaveCounter();
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="range"></param>
        public void AddRange<T>(List<T> range)
        {
            var type = typeof(T).Name;
            var maxId = GetMaxId(type);

            foreach (var t in range)
            {
                AddInstance(t, maxId, type);
                SaveCounter();
            }
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> Get<T>()
        {
            return Data.Where(c => c.Name == typeof(T).Name).Select(c => JsonConvert.DeserializeObject<T>(c.Object));
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public T Get<T>(int id) where T : new()
        {
            var data = Data.SingleOrDefault(c => c.Name == typeof(T).Name && c.Id == id);
            return data != null ? JsonConvert.DeserializeObject<T>(data.Object) : new T();
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> Read<T>()
        {
            var data = _fileSystem.Read(Path.GetFileName(typeof (T).Name));
            return _xmlDataSerializer.Deserialize<List<Instance>>(data).Select(c=>JsonConvert.DeserializeObject<T>(c.Object));
        }

        /// <summary>
        /// Updates the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public bool Update<T>(T data)
        {
            var instance = Get(data);

            if (instance == null) 
                return false;

            instance.Object = JsonConvert.SerializeObject(data);
            SaveCounter();
            return true;
        }

        /// <summary>
        /// Removes the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        public bool Remove<T>(T data)
        {
            var instance = Get(data);

            if (instance == null)
                return false;

            Data.Remove(instance);

            SaveCounter();
            return true;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public void Clear<T>()
        {
            var type = typeof (T).Name;
            Data.RemoveAll(c => c.Name == type);
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            Data.Clear();
            var files = _fileSystem.GetFiles();

            DeleteFiles(files);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        public void SubmitChanges()
        {
            var files = _fileSystem.GetFiles();
            DeleteFiles(files);

            var names = Data.Select(c => c.Name).Distinct().ToList();

            foreach (var name in names)
            {
                var related = Data.Where(c => c.Name == name).ToList();
                var serialized = _xmlDataSerializer.Serialize(related);
                _fileSystem.Write(serialized, name);
            }

            if(!_fileSystem.GetFiles().Any())
                Directory.Delete(_filePath);

            _saveCouner = 0;
        }

        private Instance Get<T>(T data)
        {
            return Data.SingleOrDefault(c => c.Name == typeof(T).Name && c.Id == ((dynamic)data).Id);
        }

        private static int GetId(List<Instance> data)
        {
            var id = 0;
            if (!data.IsNullOrEmpty())
                id = data.Max(c => c.Id);

            return ++id;
        }

        private IEnumerable<Instance> Get(string name)
        {
            return Data.Where(c => c.Name == name).ToList();
        }

        private void ReadFromFiles()
        {
            var files = _fileSystem.GetFiles();

            foreach (var deserialized in files.Select(f => _fileSystem
                .Read(Path.GetFileName(f)))
                .Select(_xmlDataSerializer.Deserialize<List<Instance>>))
            {
                Data.AddRange(deserialized);
            }
        }

        private void DeleteFiles(IEnumerable<string> files)
        {
            foreach (var f in files)
                File.Delete(f);
        }

        private void SaveCounter()
        {
            if (_numberOfUpdates == null)
                return;

            if (_saveCouner >= _numberOfUpdates)
            {
                SubmitChanges();
                _saveCouner = 0;
            }
            else
            {
                _saveCouner++;
            }
        }

        private int GetMaxId(string name)
        {
            var relatedObjects = Get(name).ToList();
            return GetId(relatedObjects);
        }

        private Instance Create(int id, string type, dynamic obj)
        {
            return new Instance
            {
                Id = id,
                Name = type,
                Object = JsonConvert.SerializeObject(obj)
            };
        }

        private void AddInstance<T>(T t, int id, string type)
        {
            var innerObject = (dynamic)t;
            innerObject.Id = id;

            var instance = Create(id, type, innerObject);

            Data.Add(instance);
        }

        private int _saveCouner;
        private readonly int? _numberOfUpdates;
        private readonly string _filePath;
        private static IFileSystem _fileSystem;
        private static IXmlDataSerializer _xmlDataSerializer;
    }
}
