using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem.Models
{
    internal class Booking
    {
        public int bookingId { get; set; }                // Unique identifier
        public int passengerId { get; set; }              // Passenger ID
        public int flightId { get; set; }                 // Flight ID
        public string seatNumber { get; set; }            // Example: 14A
        public string bookingDate { get; set; }           // Booking date
        public decimal totalPrice { get; set; }           // Paid amount
        public string status { get; set; }                // Confirmed | Cancelled
    }
}
