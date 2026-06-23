using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    internal class Passenger
    {
        public int passengerId { get; set; }              // Unique identifier
        public string passengerName { get; set; }         // Full name
        public string passengerEmail { get; set; }        // Email address
        public string passengerPhone { get; set; }        // Phone number
        public string passportNumber { get; set; }        // Unique passport/ID
        public string nationality { get; set; }           // Country

    }
}
