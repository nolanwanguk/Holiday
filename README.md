<p align="center">
  <a href="" rel="noopener">
 <img src="https://unsplash.com/photos/IrRbSND5EUc/download?ixid=MnwxMjA3fDB8MXxzZWFyY2h8OHx8ZGF0YXxlbnwwfHx8fDE2NTg2NTc0MjU&force=true&w=640" alt="Project logo"></a>
</p>
<h3 align="center">SearchAPI for holiday data</h3>

---
<div>
<p align="center"> A Test Driven C# Solution for Search data in JSON files</p>
<br>
</div>


## 📝 Table of Contents
- [Problem Statement](#problem_statement)
- [Idea / Solution](#idea)
- [Dependencies / Limitations](#limitations)
- [Future Scope](#future_scope)
- [Setting up a local environment](#getting_started)
- [Usage](#usage)
- [Technology Stack](#tech_stack)
- [Contributing](../CONTRIBUTING.md)
- [Authors](#authors)
- [Acknowledgments](#acknowledgments)

## 🧐 Problem Statement <a name = "problem_statement"></a>
The problem is to extract correct data from json files, apply several queries from input, then search results from given conditions. Finally retrive the first item with lowest total price.

- IDEAL: It should has class structures for each json file ,query statement and formatted results. Logically, it should has ioreader entity,search entity and sort entity. Program reads query to query model, then search in content which read from ioreader, then format data to return results.  

- FEATURE: Implement basic classes for extensibility, unified common variables to create interfaces, using Newtonsoft to handle json data.


## 💡 Idea / Solution <a name = "idea"></a>
### Dictionaries Tree
- Data/ 
    + which stores original json files
- IO/
    + BasicReader (fundamental interfaces and abstract classes)
    + FlightReader(read from flights.json file)
    + HotelReader(read from hotels.json file)
- Model/
    + FlightModel (store flights data into classes)
    + HotelModel (store hotels data into classes)
    + QueryModel (apply input data into classes)
    + ResultModel (store final output data into classes)
- Query/
    + BasicQuery (fundamental interfaces and abstract classes with its constructors)
    + LowestToTalPriceQuery (implement major Sort method)
- Tests/
    + FlowTests (test all logical flows and common cases)
    + IOTests (test readers)
    + ModelTest (test logics in models)
    + QueryTest (test search logics)


## ⛓️ Dependencies / Limitations <a name = "limitations"></a>
- Depends on NUnittest fromework
- Depends on Newtonsoft.net framework
- load files on local
- single search method (fit all conditions)

Using flow logics to make sure ouputs from each step are acsessible for the next.

## 🚀 Future Scope <a name = "future_scope"></a>
- [] load files on remote
- [] add inside verifications
- [] add more abnormal tests
- [] multiple search conditions

## 🏁 Getting Started <a name = "getting_started"></a>
This solution depends on .Net 6, NUnit, Newtonsoft.net which commonly runs well on Windows 7+.

### Prerequisites

We assume you have installed visual studio and .Net 6

```
git clone https://github.com/nolanwanguk/Holiday.git && cd Holiday

dotnet restore
```

### Installing

This solution doesn't need to installed.
Moreover, this solution doesn't provide any interface to show outputs and accept inputs.
Only Test cases from NUnit framework will be runable.

To run Tests, call
```
dotnet test 
```
Or using visual studio autodetect service to run/debug tests

## 🎈 Usage <a name="usage"></a>
---
### Contribute a new Query
```c#
//create a new class in Query Folder
namespace Holiday.Query;

public class NewQuery:BasicQuery
{
    public override List<Result> Sort(List<FlightModel> flights, List<HotelModel> hotels)
    {
        List<Result> Results = new List<Result>(); 
        flights = flights.OrderBy(i => CONDITIONS).ToList(); 
        hotels = hotels.OrderBy(i => CONDITIONS).ToList(); 
        for (int idx = 0; idx < (flights.Count <= hotels.Count ? flights.Count : hotels.Count); idx++)
        {
            Results.Add(new Result(flights[idx],hotels[idx]));
        }
        return Results;
    }
    
}
```
---
### Contribute a new Reader
```c#
//create a new class in IO Folder
namespace Holiday.IO;

public class NewReader:BasicReader
{
    public new int Counts;

    public new List<T> Results = new List<T>();

    public override void BeforeRead() { }
    public override void Reader(string path){ /* override Results and Counts=Results.Counts */ }
    public override void AfterRead() { }
    public override void Read(string path)
    {
        
        BeforeRead();
        Reader(path);
        AfterRead();
    }
}
```


## ⛏️ Built With <a name = "tech_stack"></a>
- [VisualStudio](https://visualstudio.microsoft.com/) - IDE
- [Newtonsoft.net](https://www.newtonsoft.com/json) - JSON Parser
- [.Net](https://dotnet.microsoft.com/en-us/) - Framework
- [NUnit](https://docs.nunit.org/index.html) - Test Environment

## ✍️ Authors <a name = "authors"></a>
- [@nolanwanguk](https://github.com/nolanwanguk)

See also the list of [contributors](https://github.com/kylelobo/The-Documentation-Compendium/contributors)
who participated in this project.
