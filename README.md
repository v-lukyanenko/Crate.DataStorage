`Crate` is an xml based local data storage with LINQ to Object interface.

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


How to start?
---  

1. Create a new instance of the DataContext <br/>
`IDataContext Dc = new DataContext(@"C:\Crate\");`

2. Add some data <br/>
`var car = new Car { Name = "Honda", Model = "Accord" };` <br/>
`Dc.Add(car);` <br/>
`Dc.SubmitChanges();`

3. Get data <br/>
`var cars = Dc.Get<Car>().Where(c => c.Name == "Honda");`

4. Get all objects of certain type directly from file <br/>
`var data = DataContext.Read<Car>();`
