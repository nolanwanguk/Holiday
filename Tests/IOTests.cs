using Holiday.IO;
namespace Holiday.Tests;

public class IOTests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test_Flight_File_Path()
    {
        var reader = new FlightsReader();
        reader.Read(@"C:\Users\nolan\RiderProjects\Holiday\Data\Flights.json");
        Assert.That(reader.Counts,Is.GreaterThan(0));
    }
    [Test]
    public void Test_Hotel_File_Path()
    {
        var reader = new HotelsReader();
        reader.Read(@"C:\Users\nolan\RiderProjects\Holiday\Data\Hotels.json");
        Assert.That(reader.Counts,Is.GreaterThan(0));
    }
}