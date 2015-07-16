# Crate.DataStorage
How to start:

1. Create a new instance of the DataContext <br/>
            `private readonly IDataContext Dc = new DataContext(@"C:\Temp\Crate\");`

2.  If you don't have any data yet add some <br/>
            var car = new Car <br/>
            {<br/>
                Name = "Honda",<br/>
                Model = "Accord",<br/>
                Prise = 33000<br/>
            };<br/>
            
            Dc.Add(car);
            Dc.SubmitChanges();

3. Now you can find your car by name for example
            var cars = Dc.Get<Car>().Where(c => c.Name == "Honda");

4. Let's add a new object 
            var person = new Person
            {
                Name = "John Doe",
                Age = 24,
                Email = "john.doe@email.com",
                Phone = "4325837421",
                CarId = 1
            };
            
5. Get all cars and ther drivers
            var query = from c in Dc.Get<Car>()
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
                        
  6. You can also get all objects from certain file to the separate list
            var allCars = DataContext.Read<Car>();
