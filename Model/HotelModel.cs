namespace Holiday.Model;

public class HotelModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Arrival_Date { get; set; }
    public int Price_Per_Night { get; set; }
    public IList<string> Local_Airports { get; set; }
    public int Nights { get; set; }

    public int TotalPrice() => Price_Per_Night * Nights;
    
}