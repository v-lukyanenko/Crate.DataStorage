
namespace Crate.Core
{
    public interface IXmlDataSerializer
    {
        /// <summary>
        /// Serializes the specified data to serialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataToSerialize">The data to serialize.</param>
        /// <returns></returns>
        string Serialize<T>(T dataToSerialize);

        /// <summary>
        /// Deserializes the specified XML text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlText">The XML text.</param>
        /// <returns></returns>
        T Deserialize<T>(string xmlText) where T : new();
    }
}
