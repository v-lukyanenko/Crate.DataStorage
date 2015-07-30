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

Objects
---

1. Create a new instance of the DataContext <br/>
    1.1 Write to File <br/>
    `IDataContext Dc = new FileContext(@"C:\Crate\");`

    1.2 Write to Sql Server Db <br/>
    `private const string ConnectionString = @"Data Source=(local);Initial Catalog=Crate;Integrated Security=true;";` <br/>
    `private static readonly IDataContext Dc = new SqlContext(ConnectionString);`
    
    1.3 Write to MySql Db <br/>
    `private const string ConnectionString = @"datasource=localhost;Database=crate;port=3306;username=root;password=root;";` <br/>
    `private static readonly IDataContext Dc = new MySqlContext(ConnectionString)`

2. Create a Storage <br/>
`var crate = new Storage("Crate");`

3. Add some data <br/>
`var car = new Car { Name = "Honda", Model = "Accord" };` <br/>
`crate.Add(car);` <br/>
`Dc.SubmitChanges(crate);`

4. Get all objects from the Storage of the certain type <br/>
`var data = Dc.Select<Person>(crate)`

5. Get specific data <br/>
`var car = Dc.Select<Person>(crate).First(c => c.Model == "Accord");`

6. Update entry <br/>
`var person = Dc.Select<Person>(crate).First(c => c.Age == 54);`<br/>
`person.Name = "John Snow";`<br/>
`crate.Update(person);`<br/>
`Dc.SubmitChanges(crate);`<br/>

7. Remove entry <br/>
`var person = Dc.Select<Person>(crate).First(c => c.Age == 54);`<br/>
`crate.Remove(person);`<br/>
`Dc.SubmitChanges(crate)`<br/>

Pairs
---

1. Write a key-value data <br/>
`DataContext.Pairs.Add("Greeting", "Hello world!");`

2. Get a value by Key <br/>
`var greeting = DataContext.Pairs.Get("Greeting");`

3. Update a value by Key <br/>
`DataContext.Pairs.Update("Greeting", "=> Hello world <=");`

4. Remove a pair by Key <br/>
`DataContext.Pairs.Remove("Greeting");`

5. Remove all Pairs <br/>
`DataContext.Pairs.ClearAll();`
