using E_CommerceSystem.Model;
using Microsoft.EntityFrameworkCore;
namespace E_CommerceSystem
{
    internal class Program
    {
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