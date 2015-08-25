using System;
using Crate.Core.DataContext;
using Crate.Core.Repositories;
using Crate.UI.Models;

namespace Crate.UI
{
    internal class Program
    {
        private const string ConnectionString =
            @"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
        
        //@"datasource=localhost;Database=crate;port=3306;username=root;password=root;";
        //@"Data Source=VLADIMIR5D4B\SQLSERVER;Initial Catalog=Crate;Integrated Security=true;";
        //@"datasource=localhost;Database=crate;port=3306;username=root;password=root;";
        //private const string FilePath = @"C:\Temp\CrateStorage\";

        private static readonly IDataContext Dc = new SqlServerContext(ConnectionString);

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
            repository.Add(p1);
            repository.Add(p2);
            Dc.SubmitChanges(repository);
            
            var people = Dc.Select<Person>(repository);

            //Dc.Clear<Person>(repository);

            Dc.Pairs.Add("Key779", "Refactored code!");

            var pair = Dc.Pairs.Get("Key779");
            Console.WriteLine(pair);
        }
    }
}
