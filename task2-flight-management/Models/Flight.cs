using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    internal class Flight
    {
        public int flightId { get; set; }                 // Unique identifier
        public string flightCode { get; set; }            // Airline flight code
        public int aircraftId { get; set; }               // Assigned aircraft ID
        public int pilotId { get; set; }                  // Assigned pilot ID
        public string origin { get; set; }                // Departure city/airport
        public string destination { get; set; }           // Arrival city/airport
        public string departureDate { get; set; }         // Departure date
        public string departureTime { get; set; }         // Departure time
        public decimal ticketPrice { get; set; }          // Price per seat
        public int availableSeats { get; set; }           // Remaining seats
        public string status { get; set; }                // Scheduled | Departed | Cancelled
    }
}
