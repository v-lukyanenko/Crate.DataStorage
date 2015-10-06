`Crate` is a jSon based data storage with a LINQ to Object interface.

Installation
---

Crate.DataStorage can be installed via the nuget UI (as [Crate.DataStorage](https://www.nuget.org/packages/Crate.DataStorage/)), 
or via the nuget package manager console:

    PM> Install-Package Crate.DataStorage

Features
--

- High performance local data storage
- Easy to start - no config files
- Easy to use - native LINQ to Object interface

Applying
--
- Prototyping
- Pet projects
- Local not highly loaded projects

How to start?
---  

Create Sql tables
---
Scripts for Sql Server and MySql databases you can find in the Scripts folder


Save Objects
---

1. Create a new instance of the DataContext <br/>
    1.1 Write to File <br/>
    `IDataContext Dc = new FileContext(@"C:\Temp\CrateStorage\", "Test");`

    1.2 Write to Sql Server Db <br/>
    `private const string ConnectionString = @"Data Source=(local);Initial Catalog=Crate;Integrated Security=true;";` <br/>
    `private static readonly IDataContext Dc = new SqlContext(ConnectionString);`
    
    1.3 Write to MySql Db <br/>
    `private const string ConnectionString = @"datasource=localhost;Database=crate;port=3306;username=root;password=root;";` <br/>
    `private static readonly IDataContext Dc = new MySqlContext(ConnectionString)`

2. Add Repository <br/>
`Dc.CreateRepository("ConsoleApp");`

3. Add objects to the repository <br/>
`Dc.CreateInstance<Car>(false, "ConsoleApp");`
`Dc.CreateInstance<Person>(false, "ConsoleApp");`

4. Create repository object <br/>
`var repository = new Repository("ConsoleApp");`

5. Save data <br/>
`var car = new Car { Name = "Honda", Model = "Accord" };` <br/>
`repository.Add(car);` <br/>
`Dc.SubmitChanges(repository);`

6. Get all objects from the Storage of the certain type <br/>
`var data = Dc.Select<Person>(repository)`

7. Get specific data <br/>
`var car = Dc.Select<Person>(crate).First(c => c.Model == "Accord");`

8. Update entry <br/>
`var car = Dc.Select<Person>(repository).First(c => c.Model == "Accord");`<br/>
`car.Model = "Lexus;`<br/>
`repository.Update(car);`<br/>
`Dc.SubmitChanges(repository);`<br/>

9. Remove entry <br/>
`var car = Dc.Select<Person>(repository).First(c => c.Model == "Accord");`<br/>
`repository.Remove(car);`<br/>
`Dc.SubmitChanges(repository)`<br/>

Save Pairs
---

1. Write a key-value data <br/>
`Dc.Pairs.Add("Key1", "Test value 1");`

2. Get a value by Key <br/>
`var temp = Dc.Pairs.Get("Key1");`

3. Update a value by Key <br/>
`DataContext.Pairs.Update("Key1", "=> Hello world <=");`

4. Remove a pair by Key <br/>
`DataContext.Pairs.Remove("Greeting");`

5. Remove all Pairs <br/>
`Dc.Pairs.ClearAll();`
