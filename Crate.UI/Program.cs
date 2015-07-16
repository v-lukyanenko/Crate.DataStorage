using System.Linq;
using Crate.Core;
using Crate.UI.Models;

namespace Crate.UI
{
    internal class Program
    {
        private static readonly IDataContext Dc = new DataContext(@"C:\Temp\Crate\");

        private static void Main(string[] args)
        {
            Init();
            Dc.SubmitChanges();

            var test = DataContext.Read<Car>();

            var cars = Dc.Get<Car>().Where(c => c.Name == "Honda");

            var result = from c in Dc.Get<Car>()
                         join p in Dc.Get<Person>() on c.Id equals p.CarId
                         select new
                         {
                             p.Name,
                             p.Email,
                             p.Phone,
                             p.Age,
                             Car = c.Name,
                             c.Prise
                         };
        }

        private static void Init()
        {
            var p1 = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
                Phone = "4325837421",
                CarId = 1
            };

            var p2 = new Person
            {
                Name = "Alex Cox",
                Age = 54,
                Email = "alex.cox@email.com",
                Phone = "758467363",
                CarId = 2
            };

            var p3 = new Person
            {
                Name = "Samanta White",
                Age = 27,
                Email = "samanta.white@email.com",
                Phone = "8235763294",
                CarId = 3
            };

            var c1 = new Car
            {
                Name = "Volvo",
                Model = "C3",
                Prise = 30000
            };

            var c2 = new Car
            {
                Name = "Honda",
                Model = "D6",
                Prise = 20000
            };

            var c3 = new Car
            {
                Name = "Wolksvagen",
                Model = "A1",
                Prise = 1000
            };

            Dc.Add(p1);
            Dc.Add(p2);
            Dc.Add(p3);

            Dc.Add(c1);
            Dc.Add(c2);
            Dc.Add(c3);
        }
    }
}
