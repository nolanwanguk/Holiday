using Holiday.Model;
using Holiday.Query;
using Holiday.IO;
namespace Holiday.Tests;

public class FlowTests
{
    public List<FlightModel> flights;
    public List<HotelModel> hotels;

    [SetUp]
    public void Setup()
    {
        var flights_reader = new FlightsReader();
        flights_reader.Read(@"C:\Users\nolan\RiderProjects\Holiday\Data\Flights.json");
        flights = flights_reader.Results;

        var hotels_reader = new HotelsReader();
        hotels_reader.Read(@"C:\Users\nolan\RiderProjects\Holiday\Data\Hotels.json");
        hotels = hotels_reader.Results;
    }

    [Test]
    public void Test_QueryCase_1()
    {
        QueryModel q = new QueryModel("MAN", "AGP", "2023/07/01", 7);
        var filter = new LowestTotalPriceQuery();
        filter.Q(q);
        filter.Query(flights, hotels);
        List<Result> Results = filter.Results;
        Assert.That(Results.First().Flight.Id,Is.EqualTo(2));
        Assert.That(Results.First().Hotel.Id,Is.EqualTo(9));
        Assert.That(Results.First().TotalPrice,Is.EqualTo("£826"));
    }
    [Test]
    public void Test_QueryCase_2()
    {
        QueryModel q = new QueryModel("Any", "PMI", "2023/06/15", 10);
        var filter = new LowestTotalPriceQuery();
        filter.Q(q);
        filter.Query(flights, hotels);
        List<Result> Results = filter.Results;
        Assert.That(Results.First().Flight.Id,Is.EqualTo(6));
        Assert.That(Results.First().Hotel.Id,Is.EqualTo(5));
        Assert.That(Results.First().TotalPrice,Is.EqualTo("£675"));
    }
    [Test]
    public void Test_QueryCase_3()
    {
        QueryModel q = new QueryModel("Any", "LPA", "2022/11/10", 14);
        var filter = new LowestTotalPriceQuery();
        filter.Q(q);
        filter.Query(flights, hotels);
        List<Result> Results = filter.Results;
        Assert.That(Results.First().Flight.Id,Is.EqualTo(7));
        Assert.That(Results.First().Hotel.Id,Is.EqualTo(6));
        Assert.That(Results.First().TotalPrice,Is.EqualTo("£1175"));
    }
}