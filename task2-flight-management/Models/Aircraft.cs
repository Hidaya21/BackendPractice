using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Aircraft
    {
        public int aircraftId { get; set; }               // system generated
        public string model { get; set; }                 // user input
        public int totalSeats { get; set; }               // user input
        public bool isOperational { get; set; }           // default value
    }
}
