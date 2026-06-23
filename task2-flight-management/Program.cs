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
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

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
                        break;
                    case 6:
                        Console.WriteLine("==== Book a Flight ====");
                        break;
                    case 7:
                        Console.WriteLine("==== Cancel a Booking ====");
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
