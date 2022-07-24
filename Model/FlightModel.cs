namespace Holiday.Model;

public readonly record struct FlightModel(int id, string airline, string from, string to, int price, string departure_date)
{
    internal readonly int Id = id;
    internal readonly string AirLine = airline;
    internal readonly string DepartingFrom = from;
    internal readonly string TravelingTo = to;
    internal readonly int Price = price;
    internal readonly DateTime DepartureDate = DateTime.Parse(departure_date);
}