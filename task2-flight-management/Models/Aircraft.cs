using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int aircraftId { get; set; }               // Unique identifier
        public string model { get; set; }                 // Aircraft model
        public int totalSeats { get; set; }               // Number of seats
        public bool isOperational { get; set; }           // Airworthy status
    }
}
