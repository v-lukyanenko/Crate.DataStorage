using System.Collections.Generic;
using Crate.Core;
using Crate.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crate.Tests
{
    [TestClass]
    public class XmlDataSerializerTests
    {
        [TestMethod]
        public void SerializeObjectToStringTest()
        {
            var serializer = new XmlDataSerializer();

            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var person = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(person);

            var actual = serializer.Serialize(dc.Data);
            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfInstance xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Instance>\r\n    <Id>1</Id>\r\n    <Name>Person</Name>\r\n    <Object>{\"Id\":1,\"Name\":\"TestPerson\",\"Email\":\"email@test.com\",\"Age\":25}</Object>\r\n  </Instance>\r\n</ArrayOfInstance>";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeserializeStringToObject()
        {
            const string xmlString = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfInstance xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <Instance>\r\n    <Id>1</Id>\r\n    <Name>Person</Name>\r\n    <Object>{\"Id\":1,\"Name\":\"TestPerson\",\"Email\":\"email@test.com\",\"Age\":25}</Object>\r\n  </Instance>\r\n</ArrayOfInstance>";

            var serializer = new XmlDataSerializer();

            var actual = serializer.Deserialize<List<Instance>>(xmlString);
            const string expected = "{\"Id\":1,\"Name\":\"TestPerson\",\"Email\":\"email@test.com\",\"Age\":25}";

            Assert.AreEqual(expected, actual[0].Object);
        }
    }
}
