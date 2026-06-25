using FlightManagementSystem.Models;
using System.Collections;
using task2_flight_management;
namespace FlightManagementSystem
{
    public class program
    {
        public static void RegisterPassenger()
        {
            Passenger p = new Passenger();
            p.passengerId = FlightContext.Passengers.Count + 1;
            Console.Write("Enter your Name: ");
            p.passengerName = Console.ReadLine();
            Console.Write("Enter your  Email: ");
            p.passengerEmail = Console.ReadLine();
            Console.Write("Enter your  Phone: ");
            p.passengerPhone = Console.ReadLine();
            Console.Write("Enter your Passport Number: ");
            p.passportNumber = Console.ReadLine();
            Console.Write("Enter your  Nationality: ");
            p.nationality = Console.ReadLine();
            FlightContext.Passengers.Add(p);
            Console.WriteLine("Passenger added successfully. ID = " + p.passengerId);
        }
        public static void AddAircraft()
        {
            Aircraft a = new Aircraft();
            a.aircraftId = FlightContext.Aircrafts.Count + 1;
            Console.Write("Model: ");
            a.model = Console.ReadLine();
            Console.Write("Total Seats: ");
            a.totalSeats = int.Parse(Console.ReadLine());
            a.isOperational = true;
            FlightContext.Aircrafts.Add(a);
            Console.WriteLine("Aircraft added successfully. ID = " + a.aircraftId);
        }
        public static void RegisterPilot()
        {
            Pilot p = new Pilot();
            p.pilotId = FlightContext.Pilots.Count + 1;
            Console.Write("Name: ");
            p.pilotName = Console.ReadLine();
            Console.Write("Phone: ");
            p.pilotPhone = Console.ReadLine();
            Console.Write("License Number: ");
            p.licenseNumber = Console.ReadLine();
            p.flightHours = 0;
            p.isAvailable = true;
            FlightContext.Pilots.Add(p);
            Console.WriteLine("Pilot added successfully. ID = " + p.pilotId);
        }
        public static void ViewAllFlights()
        {
            if (FlightContext.Flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }
            foreach (var f in FlightContext.Flights)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Flight Code: " + f.flightCode);
                Console.WriteLine("From: " + f.origin);
                Console.WriteLine("To: " + f.destination);
                Console.WriteLine("Date: " + f.departureDate);
                Console.WriteLine("Time: " + f.departureTime);
                Console.WriteLine("Available Seats: " + f.availableSeats);
                Console.WriteLine("Price: " + f.ticketPrice);
                Console.WriteLine("Status: " + f.status);
            }
        }

        public static void ScheduleFlight()
        {
            // Check aircrafts
            if (FlightContext.Aircrafts.Count == 0)
            {
                Console.WriteLine("No aircrafts available.");
                return;
            }
            // Check pilots
            if (FlightContext.Pilots.Count == 0)
            {
                Console.WriteLine("No pilots available.");
                return;
            }
            Console.WriteLine("===== AVAILABLE AIRCRAFTS =====");

            foreach (var aircraft in FlightContext.Aircrafts)
            {
                if (aircraft.isOperational == true)
                {
                    Console.WriteLine(
                        "ID: " + aircraft.aircraftId + " | Model: " + aircraft.model + " | Seats: " + aircraft.totalSeats
                    );
                }
            }
            Console.Write("Choose Aircraft ID: ");
            int aircraftId = int.Parse(Console.ReadLine());
            Aircraft selectedAircraft = null;
            foreach (var aircraft in FlightContext.Aircrafts)
            {
                if (aircraft.aircraftId == aircraftId && aircraft.isOperational == true)
                {
                    selectedAircraft = aircraft;
                }
            }
            if (selectedAircraft == null)
            {
                Console.WriteLine("Invalid aircraft.");
                return;
            }
            Console.WriteLine("===== AVAILABLE PILOTS =====");
            foreach (var pilot in FlightContext.Pilots)
            {
                if (pilot.isAvailable == true)
                {
                    Console.WriteLine(
                        "ID: " + pilot.pilotId + " | Name: " + pilot.pilotName
                    );
                }
            }
            Console.Write("Choose Pilot ID: ");
            int pilotId = int.Parse(Console.ReadLine());
            Pilot selectPilot = null;
            foreach (var pilot in FlightContext.Pilots)
            {
                if (pilot.pilotId == pilotId && pilot.pilotId == pilotId)
                {
                    if (pilot.pilotId == pilotId && pilot.isAvailable == true)
                    {
                        selectPilot = pilot;

                    }
                }

                if (selectPilot == null)
                {
                    Console.WriteLine("Invalid pilot.");
                    return;
                }
                Flight flight = new Flight();
                // Generate a unique ID for the new flight
                flight.flightId = FlightContext.Flights.Count + 1;
                // Auto generate flight code
                flight.flightCode = "OA-" + (200 + flight.flightId);
                flight.aircraftId = selectedAircraft.aircraftId;
                flight.pilotId = selectPilot.pilotId;
                Console.Write("Origin: ");
                flight.origin = Console.ReadLine();
                Console.Write("Destination: ");
                flight.destination = Console.ReadLine();
                Console.Write("Departure Date: ");
                flight.departureDate = Console.ReadLine();
                Console.Write("Departure Time: ");
                flight.departureTime = Console.ReadLine();
                Console.Write("Ticket Price: ");
                flight.ticketPrice = decimal.Parse(Console.ReadLine());
                // Seats come from aircraft
                flight.availableSeats = selectedAircraft.totalSeats;
                // Default status
                flight.status = "Scheduled";
                FlightContext.Flights.Add(flight);
                // Pilot becomes unavailable
                selectPilot.isAvailable = false;
                Console.WriteLine("Flight scheduled successfully.");
                Console.WriteLine("Flight Code: " + flight.flightCode);
            }
        }
        public static void BookFlight()
        {
            // Check passengers
            if (FlightContext.Passengers.Count == 0)
            {
                Console.WriteLine("No passengers found.");
                return;
            }
            // Check flights
            if (FlightContext.Flights.Count == 0)
            {
                Console.WriteLine("No flights available.");
                return;
            }         
            Console.WriteLine("Enter passenger ID: " );
            int passengerId = int.Parse(Console.ReadLine());
            Passenger selectedPassenger = null;

            foreach (var passenger in FlightContext.Passengers)
            {
                if (passenger.passengerId == passengerId)
                {
                    selectedPassenger = passenger;
                }
            }
            if (selectedPassenger == null)
            {
                Console.WriteLine("Passenger not found");
                return;
            }
            Console.Write("Enter Destination: ");
            string destination = Console.ReadLine();
            Console.WriteLine("===== AVAILABLE FLIGHTS =====");
            foreach (var flight in FlightContext.Flights)
            {
                if (flight.destination.ToLower() == destination.ToLower() &&
                    flight.status == "Scheduled" &&
                    flight.availableSeats > 0)
                {
                    Console.WriteLine("ID: " + flight.flightId +" | Code: " + flight.flightCode +" | From: " + flight.origin +" | To: " + flight.destination +" | Date: " + flight.departureDate + " | Seats: " + flight.availableSeats + " | Price: " + flight.ticketPrice
                    );
                }
            }
            Console.Write("Choose Flight ID: ");
            int flightId = int.Parse(Console.ReadLine());

            Flight selectedFlight = null;

            foreach (var flight in FlightContext.Flights)
            {
                if (flight.flightId == flightId &&flight.status == "Scheduled" &&flight.availableSeats > 0)
                {
                    selectedFlight = flight;
                }
            }

            if (selectedFlight == null)
            {
                Console.WriteLine("Invalid flight.");
                return;
            }
            Booking booking = new Booking();
            // Generate unique booking ID
            booking.bookingId = FlightContext.Bookings.Count + 1;
            booking.passengerId = selectedPassenger.passengerId;
            booking.flightId = selectedFlight.flightId;
            // Simple seat label generation
            booking.seatNumber = "A" + selectedFlight.availableSeats;
            Console.Write("Booking Date: ");
            booking.bookingDate = Console.ReadLine();
            // Take price from flight ticket price
            booking.totalPrice = selectedFlight.ticketPrice;
            booking.status = "Confirmed";
            FlightContext.Bookings.Add(booking);
            // Decrease available seats
            selectedFlight.availableSeats--;
            Console.WriteLine("Booking confirmed successfully.");
            Console.WriteLine("Seat Number: " + booking.seatNumber);
        } 
        public static void CancelBooking()
        {
            // Check bookings
            if (FlightContext.Bookings.Count == 0)
            {
                Console.WriteLine("No bookings found");
                return;
            }
            Console.WriteLine("===== BOOKINGS =====");
            foreach (var booking in FlightContext.Bookings)
            {
                Console.WriteLine(
                    "Booking ID: " + booking.bookingId +" | Flight ID: " + booking.flightId +" | Status: " + booking.status
                );
            }
            Console.Write("Enter Booking ID to cancel: ");
            int bookingId = int.Parse(Console.ReadLine());
            Booking selectedBooking = null;
            foreach (var booking in FlightContext.Bookings)
            {
                if (booking.bookingId == bookingId)
                {
                    selectedBooking = booking;
                }
            }
            if (selectedBooking == null)
            {
                Console.WriteLine("Booking not found");
                return;
            }
            // Check if already cancelled
            if (selectedBooking.status == "Cancelled")
            {
                Console.WriteLine("Booking is already cancelled.");
                return;
            }
            // Change booking status
            selectedBooking.status = "Cancelled";
            // Return seat to flight
            foreach (var flight in FlightContext.Flights)
            {
                if (flight.flightId == selectedBooking.flightId)
                {
                    flight.availableSeats++;
                }
            }
            Console.WriteLine("Booking cancelled successfully");
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===== FLIGHT SYSTEM =====");
                Console.WriteLine("1. Register Passenger");
                Console.WriteLine("2. Add Aircraft");
                Console.WriteLine("3. Register Pilot");
                Console.WriteLine("4. View All Flights");
                Console.WriteLine("5. Schedule a Flight");
                Console.WriteLine("6. Book a Flight");
                Console.WriteLine("7. Cancel a Booking");
                Console.WriteLine("8. Depart a Flight");
                Console.WriteLine("9. Cancel a Flight");
                Console.WriteLine("10.Passenger Booking History");
                Console.WriteLine("11.Flight Revenue & Load Factor Report");
                Console.WriteLine("0. Exit");
                Console.WriteLine("======================================");
                int choice;
                while (true)
                {
                    try
                    {
                        Console.Write("Enter your choice: ");
                        choice = int.Parse(Console.ReadLine());

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }
                switch (choice)
                {
                    case 1:
                            Console.WriteLine("==== Register Passenger ====");
                            RegisterPassenger();
                        break;
                    case 2:
                        Console.WriteLine("==== Add Aircraft ====");
                        AddAircraft();
                        break;
                    case 3:
                        Console.WriteLine("==== Register Pilot ====");
                        RegisterPilot();
                        break;
                    case 4:
                        Console.WriteLine("==== View All Flights ====");
                        ViewAllFlights();
                        break;
                    case 5:
                        Console.WriteLine("==== Schedule a Flight ====");
                        ScheduleFlight();
                        break;
                    case 6:
                        Console.WriteLine("==== Book a Flight ====");
                        BookFlight();
                        break;
                    case 7:
                        Console.WriteLine("==== Cancel a Booking ====");
                        CancelBooking();
                        break;
                    case 8:
                        Console.WriteLine("==== Depart a Flight ====");
                        break;
                    case 9:
                        Console.WriteLine("==== Cancel a Flight ====");
                        break;
                    case 10:
                        Console.WriteLine("==== Passenger Booking History ====");
                        break;
                    case 11:
                        Console.WriteLine("==== Flight Revenue & Load Factor Report ====");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.Write(" press any key to countinue...  ");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
