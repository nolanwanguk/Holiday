namespace Holiday.Model;

public record struct Result(FlightModel Flight, HotelModel Hotel)
{
        public readonly string TotalPrice = "£"+(Flight.Price + Hotel.TotalPrice()).ToString();
}