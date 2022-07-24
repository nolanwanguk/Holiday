namespace Holiday.Model;

public record struct Result(FlightModel Flight, HotelModel Hotel,int Duration)
{
    private int value = 0;
    public int TotalPrice
    {
        get => value;
        set => value = Flight.Price + Hotel.TotalPrice(Duration);
    }
}