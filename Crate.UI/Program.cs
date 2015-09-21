using System.Linq;
using Crate.Core.DataContext;
using Crate.Core.Repositories;
using Crate.UI.Models;

namespace Crate.UI
{
    internal class Program
    {
        private const string ConnectionString =
            @"datasource=localhost;Database=crate;port=3306;username=root;password=root;";

        private static readonly IDataContext Dc = new MySqlContext(ConnectionString, "Test");

        private static void Main(string[] args)
        {
            Dc.CreateRepository("ConsoleApp");

            Dc.CreateInstance<Car>(false, "ConsoleApp");
            Dc.CreateInstance<Person>(false, "ConsoleApp");

            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
                Phone = "4325837421"
            };

            var p1 = new Person
            {
                Name = "Alex Cox",
                Age = 54,
                Email = "alex.cox@email.com",
                Phone = "758467363"
            };

            var p2 = new Person
            {
                Name = "Samanta White",
                Age = 27,
                Email = "samanta.white@email.com",
                Phone = "8235763294"
            };

            var c = new Car
            {
                Name = "Toyota",
                Model = "Auris",
                Prise = 10000
            };

            var c1 = new Car
            {
                Name = "Chevrolet",
                Model = "Avensis",
                Prise = 7000
            };

            var c2 = new Car
            {
                Name = "BMW",
                Model = "X5",
                Prise = 150000
            };

            var repository = new Repository("ConsoleApp");
            repository.Add(p);
            repository.Add(p1);
            repository.Add(c);
            Dc.SubmitChanges(repository);

            var man = Dc.Select<Person>(repository).First(x => x.Age == 24);
            man.Name = "Updated Name";

            repository.Update(man);
            Dc.SubmitChanges(repository);

            var repositories = Dc.GetRepositories();
            var objects = Dc.GetObjects(repositories.First());
            repository.Remove(man);
            Dc.SubmitChanges(repository);

            repository.Add(p1);
            repository.Add(p2);

            repository.Add(c);
            repository.Add(c1);
            repository.Add(c2);

            var people = Dc.Select<Person>(repository);
            var cars = Dc.Select<Car>(repository);

            Dc.Clear<Person>(repository);

            Dc.Pairs.Add("Key1", "Test value 1");
            Dc.Pairs.Add("Key2", "Test value 2");
            Dc.Pairs.Add("Key3", "Test value 3");
        }
    }
}
