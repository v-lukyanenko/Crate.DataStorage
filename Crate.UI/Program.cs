using System;
using Crate.Core.DataContext;
using Crate.Core.Repositories;
using Crate.UI.Models;

namespace Crate.UI
{
    internal class Program
    {
        private const string ConnectionString = @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
        private static readonly IDataContext Dc = new SqlContext(ConnectionString);

        private static void Main(string[] args)
        {
            var p = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
                Phone = "4325837421",
                CarId = 1
            };

            var p1 = new Person
            {
                Name = "Alex Cox",
                Age = 54,
                Email = "alex.cox@email.com",
                Phone = "758467363",
                CarId = 2
            };

            var p2 = new Person
            {
                Name = "Samanta White",
                Age = 27,
                Email = "samanta.white@email.com",
                Phone = "8235763294",
                CarId = 3
            };

            var repository = new Repository("Rep");
            repository.Add(p);
            Dc.SubmitChanges(repository);

            var people = Dc.Select<Person>(repository);
            Dc.Clear<Person>(repository);

            Dc.Pairs.Add("Key1", "Value");
            
            Console.WriteLine(Dc.Pairs.Get("Key2"));
        }
    }
}
