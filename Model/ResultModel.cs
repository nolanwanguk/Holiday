namespace Holiday.Model;

public record struct Result(FlightModel Flight, HotelModel Hotel)
{

    public int TotalPrice { get; set; } = 0;

}