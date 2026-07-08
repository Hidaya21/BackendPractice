using E_CommerceSystem;
using E_CommerceSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceSystem
{
    public class Program
    {
        public static ECommerceContext context = new ECommerceContext();
        public static void RegisterUser()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Register New User ===");
            Console.ResetColor();
            User user = new User();
            // Name validation
            while (true)
            {
                Console.Write("Enter Name: ");
                user.Name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(user.Name))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Name cannot be empty!");
                Console.ResetColor();
            }
            // Full Name validation
            while (true)
            {
                Console.Write("Enter Full Name: ");
                user.fullName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(user.fullName))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Full Name cannot be empty!");
                Console.ResetColor();
            }
            // Email validation
            while (true)
            {
                Console.Write("Enter Email: ");
                user.email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(user.email) && user.email.Contains("@"))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid email format!");
                Console.ResetColor();
            }
            // Password validation
            while (true)
            {
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(password) && password.Length >= 6)
                {
                    user.passwordHash = password;
                    break;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password must be at least 6 characters!");
                Console.ResetColor();
            }
            // Phone validation
            while (true)
            {
                Console.Write("Enter Phone Number: ");
                user.phoneNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(user.phoneNumber) &&
                    user.phoneNumber.All(char.IsDigit))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Phone number must contain only digits!");
                Console.ResetColor();
            }
            // Address validation
            while (true)
            {
                Console.Write("Enter Address: ");
                user.address = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(user.address))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Address cannot be empty!");
                Console.ResetColor();
            }
            // Auto generated values
            user.registrationDate = DateTime.Now;
            user.isActive = true;
            context.Users.Add(user);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("User registered successfully!");
            Console.WriteLine("User ID = " + user.userId);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===== E-Commerce System =====");
                Console.WriteLine("1. Register a New User");
                Console.WriteLine("2. Add a New Product to a Category");
                Console.WriteLine("3. Place an Order");
                Console.WriteLine("4. Write a Product Review");
                Console.WriteLine("5. Update Product Price and Availability");
                Console.WriteLine("6. Cancel an Order");
                Console.WriteLine("7. Delete a Review");
                Console.WriteLine("8. View All Products");
                Console.WriteLine("9. Filter Products by Category and Price Range");
                Console.WriteLine("10.Get Category with All Its Products");
                Console.WriteLine("11.View Order History with Full Details");
                Console.WriteLine("12.Product Summary Report");
                Console.WriteLine("0. Exit");
                Console.WriteLine("======================================");
                int choice;
                while (true)
                {
                    Console.Write("Enter your choice: ");
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("==== Register a New User ====");
                        RegisterUser();
                        break;
                    case 2:
                        Console.WriteLine("====Add a New Product to a Category ====");

                        break;
                    case 3:
                        Console.WriteLine("====  Place an Order ====");

                        break;
                    case 4:
                        Console.WriteLine("==== Write a Product Review ====");

                        break;
                    case 5:
                        Console.WriteLine("==== Update Product Price and Availability ====");

                        break;
                    case 6:
                        Console.WriteLine("==== Cancel an Order ====");

                        break;
                    case 7:
                        Console.WriteLine("==== Delete a Review ====");

                        break;
                    case 8:
                        Console.WriteLine("==== View All Products ====");

                        break;
                    case 9:
                        Console.WriteLine("====  Filter Products by Category and Price Range ====");

                        break;
                    case 10:
                        Console.WriteLine("==== Get Category with All Its Products  ====");

                        break;
                    case 11:
                        Console.WriteLine("==== View Order History with Full Details ====");

                        break;
                    case 12:
                        Console.WriteLine("====  Product Summary Report ====");

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