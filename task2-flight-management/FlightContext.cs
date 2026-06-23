using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2_flight_management
{
    public static class FlightContext
    {
        public static List<Passenger> Passengers = new List<Passenger>();
        public static List<Pilot> Pilots = new List<Pilot>();
        public static List<Aircraft> Aircrafts = new List<Aircraft>();
        public static List<Flight> Flights = new List<Flight>();
        public static List<Booking> Bookings = new List<Booking>();
    }
}
