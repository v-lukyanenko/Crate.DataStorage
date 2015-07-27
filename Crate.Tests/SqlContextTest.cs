using System.Linq;
using Crate.Core.DataContext;
using Crate.Core.Repositories;
using Crate.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crate.Tests
{
    [TestClass]
    public class SqlContextTest
    {
        [TestMethod]
        public void AddANewEntryToTheRepositoryTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com"
            };

            var repository = new Repository("TestRep");

            dc.Clear<Person>(repository);

            repository.Add(p);
            dc.SubmitChanges(repository);

            var people = dc.Select<Person>(repository);

            Assert.AreEqual(1, people.Count());
        }

        [TestMethod]
        public void RemoveEntryFromRepositoryTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com"
            };

            var repository = new Repository("TestRep");

            dc.Clear<Person>(repository);

            repository.Add(p);
            dc.SubmitChanges(repository);

            repository.Remove(p);
            dc.SubmitChanges(repository);

            var people = dc.Select<Person>(repository);

            Assert.AreEqual(0, people.Count());
        }

        [TestMethod]
        public void UpdateEntryTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com"
            };

            var repository = new Repository("TestRep");

            dc.Clear<Person>(repository);

            repository.Add(p);
            dc.SubmitChanges(repository);

            var man = dc.Select<Person>(repository).First(c => c.Age == 24);
            man.Age = 35;

            repository.Update(man);
            dc.SubmitChanges(repository);

            var actual = dc.Select<Person>(repository).First(c => c.Age == 35);

            Assert.AreEqual(35, actual.Age);
        }

        [TestMethod]
        public void ClearItemsOfCertainTypeFromRepositoryTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com"
            };

            var repository = new Repository("TestRep");

            repository.Add(p);
            dc.SubmitChanges(repository);

            dc.Clear<Person>(repository);

            var people = dc.Select<Person>(repository);
            Assert.AreEqual(0, people.Count());
        }

        [TestMethod]
        public void AddNewPairTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            const string expectedValue = "Hello Pair!";

            dc.Pairs.Add("TestKey", expectedValue);
            
            var actual = dc.Pairs.Get("TestKey");
            Assert.AreEqual(true, actual.Contains(expectedValue));
        }

        [TestMethod]
        public void RemovePairTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            const string expectedValue = "Hello Pair!";

            const string pairName = "TestKey";

            dc.Pairs.Add(pairName, expectedValue);

            dc.Pairs.Remove(pairName);

            var actual = dc.Pairs.Get(pairName);
            Assert.AreEqual(false, actual.Contains(expectedValue));
        }

        [TestMethod]
        public void ClearAllPairTest()
        {
            const string connectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
            var dc = new FileContext(connectionString);

            const string expectedValue = "Hello Pair!";

            const string pairName = "TestKey";

            dc.Pairs.Add(pairName, expectedValue);

            dc.Pairs.ClearAll();

            var actual = dc.Pairs.Get(pairName);
            Assert.AreEqual(false, actual.Contains(expectedValue));
        }
    }
}
