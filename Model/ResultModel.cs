namespace Holiday.Model;

public record struct Result(FlightModel Flight, HotelModel Hotel,int Duration)
{
    
    public readonly string TotalPrice = "£"+Flight.Price + Hotel.TotalPrice(Duration).ToString();
   
}