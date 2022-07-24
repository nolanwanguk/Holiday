﻿using Holiday.Model;
namespace Holiday.Tests;

public class ModelTests
{
    [SetUp]
    public void Setup()
    { }

    [Test]
    public void Test_DateTime_Conversion_By_Slash()
    {
        string Case="2021/01/01";
        QueryModel query = new QueryModel(DepartingFrom:"A",DepartureDate: Case,TravelingTo:"B",Duration:1);
        Assert.That(query.DepartureDateConvert,Is.EqualTo(new DateTime(2021,1,1)));
    }
    [Test]
    public void Test_DateTime_Conversion_By_Minus()
    {
        string Case="2021-01-01";
        FlightModel flight = new FlightModel(airline: "A", from: "B", to: "C", id: 1, price: 100, departure_date: Case);
        Assert.That(flight.DepartureDate,Is.EqualTo(new DateTime(2021,1,1)));
    }

    [Test]
    public void Test_TotalPrice_in_HotelModel()
    {
        HotelModel hotel = new HotelModel(id:1, name:"A", arrival_date:"2023-08-09", price_per_night:10, local_airports:new string[] { "ABC" }, nights:3);
        Assert.That(hotel.TotalPrice(2),Is.EqualTo(20));
        Assert.That(hotel.TotalPrice(4),Is.EqualTo(-1));
    }

    [Test]
    public void Test_TotalPrice_in_Result()
    {
        FlightModel flight = new FlightModel(airline: "A", from: "B", to: "C", id: 1, price: 100, departure_date: "2023-08-09");
        HotelModel hotel = new HotelModel(id:1, name:"A", arrival_date:"2023-08-09", price_per_night:10, local_airports:new string[] { "ABC" }, nights:3);
        Result result = new Result(flight, hotel, 3);
        Assert.That(result.TotalPrice,Is.EqualTo("£130"));
    }
    
}