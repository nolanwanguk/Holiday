using Holiday.Model;
using Holiday.Query;
namespace Holiday.Tests;

public class QueryTests
{
    public List<FlightModel> flights;
    public List<HotelModel> hotels;

    [SetUp]
    public void Setup()
    {
        flights = new List<FlightModel>()
        {
            new FlightModel(){Id=1, AirLine="First Class Air", From="MAN", To="TFS", Price=470, Departure_Date=DateTime.Parse("2023-07-01")},
            new FlightModel(){Id=2, AirLine="Oceanic Airlines", From="MAN", To="AGP", Price=245, Departure_Date=DateTime.Parse("2023-07-01")},
            new FlightModel(){Id=6, AirLine="Fresh Airways", From="LGW", To="PMI", Price=75, Departure_Date=DateTime.Parse("2023-06-15")}
        };
        
        hotels = new List<HotelModel>()
        {
            new HotelModel(){Id=1, Name="Iberostar Grand Portals Nous", Arrival_Date=DateTime.Parse("2022-11-05"), Price_Per_Night = 100, Local_Airports = new List<string> { "TFS" }, Nights = 7},
            new HotelModel(){Id = 3, Name="Sol Katmandu Park & Resort", Arrival_Date=DateTime.Parse("2023-06-15"), Price_Per_Night = 59, Local_Airports = new List<string> { "PMI" }, Nights = 14},
            new HotelModel(){Id=9, Name="Nh Malaga", Arrival_Date=DateTime.Parse("2023-07-01"), Price_Per_Night = 83, Local_Airports = new List<string> { "AGP" }, Nights=7}
        };
    }

    [Test]
    public void Test_Sort_in_Query()
    {
        
        var filter = new LowestTotalPriceQuery();
        var q = filter.Sort(flights,hotels);
        List<Result> expected = new List<Result>()
        {
            new(flights[2], hotels[2]),
            new(flights[1], hotels[0]),
            new(flights[0], hotels[1])
        };
        Assert.That(q,Is.EqualTo(expected));
    }

    [Test]
    public void Test_Query_From_QueryModel()
    {
        QueryModel q = new QueryModel("MAN", "AGP", "2023/07/01", 7);
        var filter = new LowestTotalPriceQuery();
        filter.Q(q);
        filter.Query(flights,hotels);
        Assert.That(filter.Results.Count,Is.EqualTo(1));
        Assert.That(filter.Results.First().Flight.Id,Is.EqualTo(2));
        Assert.That(filter.Results.First().Hotel.Id,Is.EqualTo(9));
    }
}