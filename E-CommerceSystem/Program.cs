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
                if (!string.IsNullOrWhiteSpace(user.phoneNumber) && user.phoneNumber.All(char.IsDigit))
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
        public static void AddProduct()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Add New Product ===");
            Console.ResetColor();
            // Display all categories
            var categories = context.Categories.ToList();
            if (categories.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No categories available!");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Available Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine(category.categoryId + " - " + category.categoryName);
            }
            // Read category selection
            Console.Write("Choose Category ID: ");
            int categoryId = int.Parse(Console.ReadLine());
            var selectedCategory = categories.FirstOrDefault(c => c.categoryId == categoryId);
            if (selectedCategory == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Category not found!");
                Console.ResetColor();
                return;
            }
            // Create product
            Product product = new Product();
            Console.Write("Enter Product Name: ");
            product.productName = Console.ReadLine();
            Console.Write("Enter Description: ");
            product.description = Console.ReadLine();
            Console.Write("Enter Price: ");
            product.price = double.Parse(Console.ReadLine());
            Console.Write("Enter Stock Quantity: ");
            product.stockQuantity = int.Parse(Console.ReadLine());
            Console.Write("Enter Image URL: ");
            product.imageUrl = Console.ReadLine();
            // Set category
            product.categoryId = selectedCategory.categoryId;
            // Auto generated values
            product.createdAt = DateTime.Now;
            product.isAvailable = true;
            // Save product
            context.Products.Add(product);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product added successfully!");
            Console.WriteLine("Product ID = " + product.productId);
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
                        RegisterUser();
                        break;
                    case 2:
                        AddProduct();
                        break;
                    case 3:
                        
                        break;
                    case 4:
                        

                        break;
                    case 5:
                       

                        break;
                    case 6:
                       

                        break;
                    case 7:
                     

                        break;
                    case 8:
                       
                        break;
                    case 9:
                  

                        break;
                    case 10:

                        break;
                    case 11:
                        

                        break;
                    case 12:
                      
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