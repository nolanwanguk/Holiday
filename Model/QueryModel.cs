namespace Holiday.Model;

public record struct QueryModel(string DepartingFrom,string TravelingTo,string DepartureDate,int Duration)
{
    internal DateTime DepartureDateConvert { get; init; } = DateTime.Parse(DepartureDate);
}