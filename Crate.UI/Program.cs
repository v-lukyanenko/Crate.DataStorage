using System.Linq;
using Crate.Core;
using Crate.UI.Models;

namespace Crate.UI
{
    internal class Program
    {
        private static readonly IDataContext Dc = new DataContext(@"C:\Temp\");

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

            DataContext.Pairs.Add("Greeting", "Hello world!");

            var greeting = DataContext.Pairs.Get("Greeting");

            DataContext.Pairs.Update("Greeting", "=> Hello world <=");

            DataContext.Pairs.Remove("Greeting");

            var crate = new Storage("Crate");

            crate.Add(p);
            crate.Add(p1);
            crate.Add(p2);

            Dc.SubmitChanges(crate);

            var person = Dc.Select<Person>(crate).First(c => c.Age == 54);
            crate.Remove(person);
            Dc.SubmitChanges(crate);
            
            DataContext.Pairs.ClearAll();
            Dc.SubmitChanges(crate);
        }
    }
}
