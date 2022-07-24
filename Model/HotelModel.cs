﻿namespace Holiday.Model;

public readonly record struct HotelModel(int id,string name,string arrival_date,int price_per_night,string[] local_airports,int nights)
{
    internal readonly int Id = id;
    internal readonly string Name = name;
    internal readonly DateTime ArrvialDate = DateTime.Parse(arrival_date);
    internal readonly int Price = price_per_night * nights;
    internal readonly string[] LocalAirports = local_airports;
    internal readonly int Nights = nights;
}