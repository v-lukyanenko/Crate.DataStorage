using System;
using Newtonsoft.Json;

namespace Crate.Core.Models
{
    public class Instance
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        /// <value>
        /// The object.
        /// </value>
        public string Object { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [JsonIgnore]
        public OperationType Type { get; set; }
    }
}
