
using System.Collections.Generic;

namespace Crate.Core.Models
{
    public class InstanceType
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public Dictionary<string, string> Properties { get; set; }

        /// <summary>
        /// Gets or sets the repository identifier.
        /// </summary>
        /// <value>
        /// The repository identifier.
        /// </value>
        public int RepositoryId { get; set; }
    }
}
