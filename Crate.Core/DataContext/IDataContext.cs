using System.Collections.Generic;
using Crate.Core.Pairs;
using Crate.Core.Repositories;

namespace Crate.Core.DataContext
{
    public interface IDataContext
    {
        /// <summary>
        /// Gets or sets the pairs.
        /// </summary>
        /// <value>
        /// The pairs.
        /// </value>
        IPair Pairs { get; set; }

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        IEnumerable<T> Select<T>(IRepository repository);

        /// <summary>
        /// Selects the specified repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        IEnumerable<Dictionary<string, object>> Select(string repository, string dataType);

        /// <summary>
        /// Submits the changes.
        /// </summary>
        /// <param name="repository">The repository.</param>
        bool SubmitChanges(IRepository repository);

        /// <summary>
        /// Clears the specified repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="repository">The repository.</param>
        void Clear<T>(IRepository repository);

        /// <summary>
        /// Clears all.
        /// </summary>
        void ClearAll();

        /// <summary>
        /// Gets all repositories.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetRepositories();

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns></returns>
        List<string> GetObjects(string repository);

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void CreateInstance<T>(bool hardSaving, string repository);

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        void CreateRepository(string repository);

        /// <summary>
        /// Checks the data types.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <returns></returns>
        bool CheckDataTypes(Dictionary<string, string> data, string objectName, string repository);

        /// <summary>
        /// Gets the object structure.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="repository"></param>
        /// <returns></returns>
        Dictionary<string, string> GetObjectStructure(string name, string repository);
    }
}