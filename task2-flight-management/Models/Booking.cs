using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    public class Booking
    {
        public int bookingId { get; set; }                // System generated
        public int passengerId { get; set; }               // From list
        public int flightId { get; set; }                  // From list
        public string seatNumber { get; set; }             // System generated
        public string bookingDate { get; set; }           
        public decimal totalPrice { get; set; }           // Calculate
        public string status { get; set; }                // Default Value
    }
}
