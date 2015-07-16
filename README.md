# Crate.DataStorage
How to start:

1. Create a new instance of the DataContext <br/>
            `private readonly IDataContext Dc = new DataContext(@"C:\Temp\Crate\");`

2.  If you don't have any data yet add some <br/>
            `var car = new Car` <br/>
            `{`<br/>
                `Name = "Honda",`<br/>
                `Model = "Accord",`<br/>
                `Prise = 33000`<br/>
            `};`<br/>
            `Dc.Add(car);`
            `Dc.SubmitChanges();`

3. Now you can find your car by name for example <br/>
            `var cars = Dc.Get<Car>().Where(c => c.Name == "Honda");`

4. Let's add a new object  <br/>
            `var person = new Person` <br/>
            `{` <br/>
                `Name = "John Doe",` <br/>
                `Age = 24,` <br/>
                `Email = "john.doe@email.com",` <br/>
                `Phone = "4325837421",` <br/>
                `CarId = 1` <br/>
            `};` <br/>
            
5. Get all cars and ther drivers <br/>
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
                        
  6. You can also get all objects from certain file to the separate list <br/>
            `var allCars = DataContext.Read<Car>();`
