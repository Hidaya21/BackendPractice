using FlightManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace task2_flight_management
{
    public class FlightContext
    {
        public  List<Passenger> Passengers ;
        public List<Pilot> Pilots;
        public List<Aircraft> Aircrafts ;
        public  List<Flight> Flights ;
        public List<Booking> Bookings ;
    }
}
