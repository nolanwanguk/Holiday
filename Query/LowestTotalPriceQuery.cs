using System.Runtime.CompilerServices;
using Holiday.Model;
namespace Holiday.Query;

public class LowestTotalPriceQuery:BasicQuery
{
    public override List<Result> Sort(List<FlightModel> flights, List<HotelModel> hotels)
    {
        List<Result> Results = new List<Result>();
        flights = flights.OrderBy(i => i.Price).ToList();
        hotels = hotels.OrderBy(i => i.TotalPrice()).ToList();
        for (int idx = 0; idx < (flights.Count <= hotels.Count ? flights.Count : hotels.Count); idx++)
        {
            Results.Add(new Result(flights[idx],hotels[idx]));
        }
        return Results;
    }
    
}