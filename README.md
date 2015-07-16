# Crate.DataStorage
How to start:

1. Create a new instance of the DataContext <br/><br/>
            `private readonly IDataContext Dc = new DataContext(@"C:\Temp\Crate\");`
<br/><br/>
2.  If you don't have any data yet add some <br/><br/>
            ```
            var car = new Car<br/>
            {<br/>
                Name = "Honda",<br/>
                Model = "Accord",<br/>
                Prise = 33000<br/>
            };<br/>
            Dc.Add(car);
            Dc.SubmitChanges();
            ```
<br/><br/>
3. Now you can find your car by name for example <br/><br/>
            `var cars = Dc.Get<Car>().Where(c => c.Name == "Honda");`
<br/><br/>
4. Let's add a new object  <br/><br/>
            `var person = new Person` <br/>
            `{` <br/>
                `Name = "John Doe",` <br/>
                `Age = 24,` <br/>
                `Email = "john.doe@email.com",` <br/>
                `Phone = "4325837421",` <br/>
                `CarId = 1` <br/>
            `};` <br/>
<br/><br/>
5. Get all cars and ther drivers <br/><br/>
            `var query = from c in Dc.Get<Car>()` <br/>
                        `join p in Dc.Get<Person>() on c.Id equals p.CarId` <br/>
                        `select new` <br/>
                        `{` <br/>
                           `p.Name,` <br/>
                           `p.Email,` <br/>
                           `p.Phone,` <br/>
                           `p.Age,` <br/>
                           `Car = c.Name,` <br/>
                           `c.Prise` <br/>
                        `};` <br/>
<br/><br/>
6. You can also get all objects from certain type to the separate list <br/><br/>
            `var allCars = DataContext.Read<Car>();`
