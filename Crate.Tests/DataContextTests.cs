using System;
using System.Collections.Generic;
using System.Linq;
using Crate.Core;
using Crate.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crate.Tests
{
    [TestClass]
    public class DataContextTests
    {
        [ExpectedException(typeof(ArgumentException), "Path cannot be the empty string or all whitespace.")]
        [TestMethod]
        public void CreateNewInstanceWithEmptyFilePathTest()
        {
            const string path = @"";
            var dc = new DataContext(path);
        }

        [TestMethod]
        public void CreateNewInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var actual = dc.Data.Count;
            const int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddNewInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var obj = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(obj);

            var actual = dc.Data.Count;
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddRangeOfNewInstancesTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var people = new List<Person>
            {
                new Person()
                {
                    Name = "TestPerson",
                    Email = "email@test.com",
                    Age = 25
                },
                new Person()
                {
                    Name = "TestPerson1",
                    Email = "email1@test.com",
                    Age = 26
                },
                new Person()
                {
                    Name = "TestPerson2",
                    Email = "email2@test.com",
                    Age = 27
                }
            };

            dc.AddRange(people);

            var actual = dc.Data.Count;
            const int expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var obj = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(obj);

            var actual = dc.Get<Person>().Count();
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetInstanceByIdTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var obj = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(obj);
            var actual = dc.Get<Person>(1).Name;
            const string expected = "TestPerson";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var obj = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(obj);

            var person = dc.Get<Person>(1);
            person.Name = "Updated";
            dc.Update(person);
            

            var actual = dc.Get<Person>(1).Name;
            const string expected = "Updated";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var obj = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            dc.Add(obj);

            var person = dc.Get<Person>(1);
            dc.Remove(person);

            var actual = dc.Data.Count;
            const int expected = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearInstanceTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var person = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            var car = new Car
            {
                Model = "TestCar",
                Prise = 1000,
                
            };

            dc.Add(person);
            dc.Add(car);
            
            dc.Clear<Person>();

            var actual = dc.Data.Count;
            const int expected = 1;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClearAllInstancesTest()
        {
            const string path = @"C:\Temp\TestDb";
            var dc = new DataContext(path);

            var person = new Person
            {
                Name = "TestPerson",
                Email = "email@test.com",
                Age = 25
            };

            var car = new Car
            {
                Model = "TestCar",
                Prise = 1000,
            };

            dc.Add(person);
            dc.Add(car);

            dc.ClearAll();

            var actual = dc.Data.Count;
            const int expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}
