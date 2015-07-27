using System.Linq;
using Crate.Core;
using Crate.Core.Repositories;
using Crate.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crate.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void AddNewInstanceTest()
        {
            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
            };

            var crate = new Repository("Crate");
            crate.Add(p);

            const int expected = 1;
            var actual = crate.Data.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateInstanceTest()
        {
            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
            };

            var crate = new Repository("Crate");

            crate.Update(p);

            var actual = crate.Data.First(c => c.Name == "Person").Type;

            const OperationType expected = OperationType.Updating;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveInstanceTest()
        {
            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
            };

            var crate = new Repository("Crate");

            crate.Remove(p);

            var actual = crate.Data.First(c => c.Name == "Person").Type;

            const OperationType expected = OperationType.Removing;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UndoPandingChangesTest()
        {
            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
            };

            var crate = new Repository("Crate");
            crate.Add(p);

            crate.UndoPendingChanges();

            const int expected = 0;
            var actual = crate.Data.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
