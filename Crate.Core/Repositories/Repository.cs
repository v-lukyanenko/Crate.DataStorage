using System;
using System.Collections;
using System.Collections.Generic;
using Crate.Core.Models;
using Newtonsoft.Json;

namespace Crate.Core.Repositories
{
    public class Repository : IRepository
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public List<Instance> Data { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Repository(string name)
        {
            Data = new List<Instance>();
            Name = name;
        }

        #region Public Methods
        /// <summary>
        /// Adds the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Add<T>(T t)
        {
            IsEnumerable(t);

            var current = (dynamic) t;
            current.Id = Guid.NewGuid();

            AddInstance(t, OperationType.Saving);
        }

        /// <summary>
        /// Updates the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Update<T>(T t)
        {
            IsEnumerable(t);
            AddInstance(t, OperationType.Updating);
        }

        /// <summary>
        /// Removes the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        public void Remove<T>(T t)
        {
            IsEnumerable(t);
            AddInstance(t, OperationType.Removing);
        }

        /// <summary>
        /// Undoes the pending changes.
        /// </summary>
        public void UndoPendingChanges()
        {
            Data.Clear();
        }
        #endregion

        #region Private Region
        private static void IsEnumerable<T>(T t)
        {
            if(typeof(T).Name.Contains(typeof(IEnumerable).Name))
                throw new Exception(Resource.IEnumerableError);
        }

        private void AddInstance<T>(T t, OperationType operationType)
        {
            var type = typeof(T).Name;
            var instance = Create(type, t, operationType);
            Data.Add(instance);
        }

        private static Instance Create(string type, dynamic obj, OperationType operationType)
        {
            return new Instance
            {
                Id = obj.Id,
                Name = type,
                Object = JsonConvert.SerializeObject(obj),
                Type = operationType
            };
        }
        #endregion
    }
}
