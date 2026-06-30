using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Flight
    {
        public int flightId { get; set; }                 // System generated
        public string flightCode { get; set; }            // system generated
        public int aircraftId { get; set; }               // From list
        public int pilotId { get; set; }                  // From list
        public string origin { get; set; }                // User input
        public string destination { get; set; }           // User input
        public int flightDuration { get; set; }           //User input
        public string departureDate { get; set; }         // User input
        public string departureTime { get; set; }         // User input
        public decimal ticketPrice { get; set; }          // Calculated
        public int availableSeats { get; set; }           //Default Value
        public string status { get; set; }                // Default Value
    }
}
