using System.Runtime.CompilerServices;
using Holiday.Model;
namespace Holiday.Query;

public class LowestTotalPriceQuery:BasicQuery
{
    public List<Result>? Results { get; set; }
    
    public override void Q(QueryModel q)
    {
        DepartingFrom = q.DepartingFrom;
        TravelingTo = q.TravelingTo;
        DepartureDate = q.DepartureDateConvert;
        Duration = q.Duration;
    }
    public override void Query(List<FlightModel> flights, List<HotelModel> hotels)
    {
        List<FlightModel> flight = flights.FindAll(i =>
            i.DepartingFrom == DepartingFrom && i.TravelingTo == this.TravelingTo &&
            i.DepartureDate == this.DepartureDate);
        List<HotelModel> hotel = hotels.FindAll(i =>
            i.ArrvialDate == this.DepartureDate && i.LocalAirports.Contains(this.TravelingTo) &&
            i.Nights >= this.Duration);
        
        this.Results = Sort(flight, hotel);
    }
    public override List<Result> Sort(List<FlightModel> flights, List<HotelModel> hotels)
    {
        List<Result> Results = new List<Result>();
        flights = flights.OrderBy(i => i.Price).ToList();
        hotels = hotels.OrderBy(i => i.TotalPrice(this.Duration)).ToList();
        for (int idx = 0; idx < (flights.Count <= hotels.Count ? flights.Count : hotels.Count); idx++)
        {
            Results.Add(new Result(flights[idx],hotels[idx],this.Duration));
        }
        return Results;
    }
    
}