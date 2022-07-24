namespace Holiday.Model;

public class FlightModel
{
    public int Id { get; set; }
    public string AirLine { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public int Price { get; set; }
    public DateTime Departure_Date { get; set; }
}