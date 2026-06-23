using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Pilot
    {
        public int pilotId { get; set; }                  // Unique identifier
        public string pilotName { get; set; }             // Full name
        public string pilotPhone { get; set; }            // Contact number
        public string licenseNumber { get; set; }         // Aviation license
        public int flightHours { get; set; }              // Total flight hours
        public bool isAvailable { get; set; }             // Availability status
    }
}
