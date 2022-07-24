using Holiday.Model;

namespace Holiday.Query;

public interface IBasicQuery
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
    public List<Result>? Results { get; set; }
    public void Q(QueryModel q);
    public void Query(List<FlightModel> flights, List<HotelModel> hotels);
}

public abstract class BasicQuery:IBasicQuery
{
    public string DepartingFrom { get; set; }
    public string TravelingTo { get; set; }
    public DateTime DepartureDate { get; set; }
    public int Duration { get; set; }
    
    public List<Result>? Results { get; set; }

    public void Q(QueryModel q)
    {
        DepartingFrom = q.DepartingFrom;
        TravelingTo = q.TravelingTo;
        DepartureDate = q.DepartureDateConvert;
        Duration = q.Duration;
    }

    public void Query(List<FlightModel> flights, List<HotelModel> hotels)
    {
        List<FlightModel> flight = flights.FindAll(i =>
            i.DepartingFrom == DepartingFrom && i.TravelingTo == this.TravelingTo &&
            i.DepartureDate == this.DepartureDate);
        List<HotelModel> hotel = hotels.FindAll(i =>
            i.ArrvialDate == this.DepartureDate && i.LocalAirports.Contains(this.TravelingTo) &&
            i.Nights >= this.Duration);
        
        this.Results = Sort(flight, hotel);
    }

    public abstract List<Result> Sort(List<FlightModel> flights, List<HotelModel> hotels);
}