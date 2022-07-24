using Holiday.Model;
using Holiday.Query;
namespace Holiday.Tests;

public class QueryTests
{
    [SetUp]
    public void Setup(){}

    [Test]
    public void Test_Sort_in_Query()
    {
        List<FlightModel> flights = new List<FlightModel>()
        {
            new(1, "First Class Air", "MAN", "TFS", 470, "2023-07-01"),
            new(2, "Oceanic Airlines", "MAN", "AGP", 245, "2023-07-01"),
            new(6, "Fresh Airways", "LGW", "PMI", 75, "2023-06-15")
        };
        List<HotelModel> hotels = new List<HotelModel>()
        {
            new(1, "Iberostar Grand Portals Nous", "2022-11-05", 100, new string[] { "TFS" }, 7),
            new(3, "Sol Katmandu Park & Resort", "2023-06-15", 59, new string[] { "PMI" }, 14),
            new(9, "Nh Malaga", "2023-07-01", 83, new string[] { "AGP" }, 7)
        };

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
}