using Holiday.Model;
namespace Holiday.Tests;

public class ModelTests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void Test_TotalPrice_in_HotelModel()
    {
        HotelModel hotel = new HotelModel(){Id=1, Name= "A", Arrival_Date= DateTime.Parse("2023-08-09"), Price_Per_Night= 10, Local_Airports= new List<string>{ "ABC" }, Nights= 3};
        Assert.That(hotel.TotalPrice(),Is.EqualTo(30));
    }

    [Test]
    public void Test_TotalPrice_in_Result()
    {
        FlightModel flight = new FlightModel(){AirLine= "A", From= "B", To= "C", Id=1, Price=100, Departure_Date= DateTime.Parse("2023-08-09")};
        HotelModel hotel = new HotelModel(){Id=1, Name= "A", Arrival_Date= DateTime.Parse("2023-08-09"), Price_Per_Night= 10, Local_Airports= new List<string>{ "ABC" }, Nights= 3};
        Result result = new Result(flight, hotel);
        Assert.That(result.TotalPrice,Is.EqualTo("£130"));
    }
    
}