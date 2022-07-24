using Holiday.Model;

namespace Holiday.Query;

public abstract class BasicQuery
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
    
    public List<Result>? Results { get; set; }

    public abstract void Q(QueryModel q);

    public abstract void Query(List<FlightModel> flights, List<HotelModel> hotels);
    public abstract List<Result> Sort(List<FlightModel> flights, List<HotelModel> hotels);
}