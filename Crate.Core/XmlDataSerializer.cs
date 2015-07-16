using System.Xml.Serialization;

namespace Crate.Core
{
    public class XmlDataSerializer : IXmlDataSerializer
    {
        /// <summary>
        /// Serializes the specified data to serialize.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataToSerialize">The data to serialize.</param>
        /// <returns></returns>
        public string Serialize<T>(T dataToSerialize)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stringwriter, dataToSerialize);
            return stringwriter.ToString();
        }

        /// <summary>
        /// Deserializes the specified XML text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlText">The XML text.</param>
        /// <returns></returns>
        public T Deserialize<T>(string xmlText) where T : new()
        {
            if (string.IsNullOrWhiteSpace(xmlText))
                return new T();

            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stringReader);
        }
    }
}
