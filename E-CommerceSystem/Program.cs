using E_CommerceSystem;
using E_CommerceSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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
            product.price = decimal.Parse(Console.ReadLine());
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
        public static void PlaceOrder()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Place Order ===");
            Console.ResetColor();
            // Display Users
            Console.WriteLine("Available Users:");
            foreach (var user in context.Users.ToList())
            {
                Console.WriteLine(user.userId + " - " + user.Name);
            }
            Console.Write("Enter Customer ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.WriteLine("Invalid Customer ID!");
                return;
            }
            // Check customer exists
            User customer = context.Users.FirstOrDefault(u => u.userId == userId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found!");
                return;
            }
            // Get shipping information
            Console.Write("Enter Shipping Address: ");
            string shippingAddress = Console.ReadLine();
            Console.Write("Enter Payment Method: ");
            string paymentMethod = Console.ReadLine();
            // Create Order first
            Order order = new Order();
            order.userId = userId;
            order.orderDate = DateTime.Now;
            order.totalAmount = 0;
            order.shippingAddress = shippingAddress;
            order.paymentMethod = paymentMethod;
            context.Orders.Add(order);
            // Generate Order ID
            context.SaveChanges();
            decimal totalAmount = 0;
            while (true)
            {
                Console.WriteLine("\nAvailable Products:");
                foreach (var product in context.Products.ToList())
                {
                    Console.WriteLine(
                        product.productId +
                        " - " +
                        product.productName +
                        " | Price: " +
                        product.price +
                        " | Stock: " +
                        product.stockQuantity
                    );
                }
                Console.Write("Enter Product ID (0 to finish): ");
                if (!int.TryParse(Console.ReadLine(), out int productId))
                {
                    Console.WriteLine("Invalid Product ID!");
                    continue;
                }
                if (productId == 0)
                    break;
                Product selectedProduct = context.Products.FirstOrDefault(p => p.productId == productId);
                if (selectedProduct == null)
                {
                    Console.WriteLine("Product not found!");
                    continue;
                }
                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.WriteLine("Invalid quantity!");
                    continue;
                }
                if (quantity <= 0)
                {
                    Console.WriteLine("Quantity must be greater than zero!");
                    continue;
                }
                if (quantity > selectedProduct.stockQuantity)
                {
                    Console.WriteLine("Not enough stock!");
                    continue;
                }
               // Create OrderItem
                OrderItem item = new OrderItem();
                item.orderId = order.orderId;
                item.productId = selectedProduct.productId;
                item.unitPrice = selectedProduct.price;
                item.quantity = quantity;
                context.OrderItems.Add(item);
                // Calculate total
                totalAmount += item.unitPrice * item.quantity;
                // Reduce stock
                selectedProduct.stockQuantity -= quantity;
            }
            // Update order total
            order.totalAmount = totalAmount;
            // Save OrderItems + Stock + Total
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order placed successfully!");
            Console.WriteLine("Order ID: " + order.orderId);
            Console.WriteLine("Total Amount: " + order.totalAmount);

            Console.ResetColor();
        }
        public static void WriteProductReview()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Write Product Review ===");
            Console.ResetColor();
            // Display users
            Console.WriteLine("Available Users:");
            foreach (var user in context.Users.ToList())
            {
                Console.WriteLine(user.userId + " - " + user.Name);
            }
            // Display products
            Console.WriteLine("Available Products: ");
            foreach (var product in context.Products.ToList())
            {
                Console.WriteLine(product.productId + " - " + product.productName);
            }
            Review review = new Review();
            // Select User
            Console.Write("Enter User ID: ");
            review.userId = int.Parse(Console.ReadLine());
            // Select Product
            Console.Write("Enter Product ID: ");
            review.productId = int.Parse(Console.ReadLine());
            // Rating Validation
            while (true)
            {
                Console.Write("Enter Rating (1-5): ");
                review.rating = int.Parse(Console.ReadLine());
                if (review.rating >= 1 && review.rating <= 5)
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Rating must be between 1 and 5.");
                Console.ResetColor();
            }
            Console.Write("Enter Review ID: ");
            review.reviewId = int.Parse(Console.ReadLine());
            // Comment
            Console.Write("Enter Comment (optional): ");
            review.comment = Console.ReadLine();
            // System generated
            review.reviewDate = DateTime.Now;
            // Save
            context.Reviews.Add(review);
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Review added successfully!");
            Console.WriteLine("Review ID = " + review.reviewId);
            Console.ResetColor();
        }
        public static void UpdateProductPriceAndAvailability()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Update Product Price and Availability ===");
            Console.ResetColor();
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            // Fetch product using FirstOrDefault()
            Product product = context.Products.FirstOrDefault(p => p.productId == productId);

            if (product == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Product not found!");
                Console.ResetColor();
                return;
            }
            Console.WriteLine("Current Product Information:");
            Console.WriteLine("Name: " + product.productName);
            Console.WriteLine("Current Price: "+product.price);
            Console.WriteLine("Available: "+ product.isAvailable);
           // Update fields
            Console.Write("Enter New Price: ");
            product.price = decimal.Parse(Console.ReadLine());
            Console.Write("Is Product Available? (true/false): ");
            product.isAvailable = bool.Parse(Console.ReadLine());
            // Save changes
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product updated successfully!");
            Console.ResetColor();
            Console.WriteLine("New Price: " + product.price);
            Console.WriteLine("New Availability: " + product.isAvailable );
        }
        public static void CancelOrder()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Cancel Order ===");
            Console.ResetColor();
            // Display Orders
            Console.WriteLine("Available Orders:");
            foreach (var order in context.Orders.ToList())
            {
                Console.WriteLine("Order ID: " + order.orderId +" | Customer ID: " + order.userId + " | Status: " + order.status);
            }
            Console.Write("Enter Order ID: ");
            if (!int.TryParse(Console.ReadLine(), out int orderId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Order ID.");
                Console.ResetColor();
                return;
            }
            // Find Order
            Order orderToCancel = context.Orders.FirstOrDefault(o => o.orderId == orderId);
            if (orderToCancel == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Order not found.");
                Console.ResetColor();
                return;
            }
            // Check if already cancelled
            if (orderToCancel.status == "Cancelled")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This order has already been cancelled.");
                Console.ResetColor();
                return;
            }
            // Load Order Items
            var orderItems = context.OrderItems.Where(oi => oi.orderId == orderId).ToList();
            // Restore Stock
            foreach (var item in orderItems)
            {
                Product product = context.Products.FirstOrDefault(p => p.productId == item.productId);
                if (product != null)
                {
                    product.stockQuantity += item.quantity;
                }
            }
            // Update Status
            orderToCancel.status = "Cancelled";
            // Save Changes
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order cancelled successfully.");
            Console.ResetColor();
        }
        public static void DeleteReview()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Delete Review ===");
            Console.ResetColor();
            // Display Reviews
            Console.WriteLine("Available Reviews:");
            foreach (var review in context.Reviews.ToList())
            {
                Console.WriteLine("Review ID: " + review.reviewId + " | Product ID: " + review.productId + "| Rating: " + review.rating);
            }
            Console.Write("Enter Review ID to delete: ");

            if (!int.TryParse(Console.ReadLine(), out int reviewId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Review ID.");
                Console.ResetColor();
                return;
            }
            // Find Review
            Review reviewToDelete = context.Reviews.FirstOrDefault(r => r.reviewId == reviewId);
            if (reviewToDelete == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Review not found.");
                Console.ResetColor();
                return;
            }
            // Delete Review
            context.Reviews.Remove(reviewToDelete);
            // Save Changes
            context.SaveChanges();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Review deleted successfully");
            Console.ResetColor();
        }
        public static void ViewAllProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== All Products ===");
            Console.ResetColor();
            // Get all products
            var products = context.Products.ToList();
            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No products found.");
                Console.ResetColor();
                return;
            }
            // Display products
            foreach (var product in products)
            {
                string status = product.stockQuantity > 0? "Available": "Out of Stock";

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Product ID : " + product.productId);
                Console.WriteLine("Name       : " + product.productName);
                Console.WriteLine("Price      : " + product.price);
                Console.WriteLine("Stock      : " + product.stockQuantity);
                Console.WriteLine("Status     : " + status);
            }
            Console.WriteLine("-------------------------------------");
        }
        public static void FilterProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Filter Products ===");
            Console.ResetColor();
            // Display Categories
            Console.WriteLine("Available Categories:");
            foreach (var category in context.Categories.ToList())
            {
                Console.WriteLine(category.categoryId+" - " + category.categoryName);
            }
            // Category ID
            Console.Write("Enter Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Category ID.");
                Console.ResetColor();
                return;
            }
            // Minimum Price
            Console.Write("Enter Minimum Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Minimum Price.");
                Console.ResetColor();
                return;
            }
            // Maximum Price
            Console.Write("Enter Maximum Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Maximum Price.");
                Console.ResetColor();
                return;
            }
            // Filter Products
            var products = context.Products
                .Where(p => p.categoryId == categoryId && p.price >= minPrice &&p.price <= maxPrice)
                .OrderBy(p => p.price)
                .ToList();

            if (products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No matching products found.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Filtered Products:");
            Console.ResetColor();
            foreach (var product in products)
            {
                string status = product.stockQuantity > 0? "Available": "Out of Stock";
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Product ID : " + product.productId);
                Console.WriteLine("Name       : " + product.productName);
                Console.WriteLine("Price      : "+ product.price);
                Console.WriteLine("Stock      : "+product.stockQuantity);
                Console.WriteLine("Status     : " +  status);
            }
            Console.WriteLine("-------------------------------------");
        }
        public static void GetCategoryWithProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Category with Products ===");
            Console.ResetColor();
            // Display Categories
            Console.WriteLine("Available Categories:");

            foreach (var category in context.Categories.ToList())
            {
                Console.WriteLine(category.categoryId + " - " + category.categoryName);
            }
            Console.Write("Enter Category ID: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Category ID.");
                Console.ResetColor();
                return;
            }
            // Get Category with Products
            Category categoryData = context.Categories.Include(c => c.Products).FirstOrDefault(c => c.categoryId == categoryId);
            if (categoryData == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Category not found.");
                Console.ResetColor();
                return;
            }
            // Display Category Details
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Category Details");
            Console.ResetColor();
            Console.WriteLine($"Category ID   : {categoryData.categoryId}");
            Console.WriteLine($"Name          : {categoryData.categoryName}");
            Console.WriteLine($"Description   : {categoryData.description}");
            Console.WriteLine("Products:");
            if (categoryData.Products.Count == 0)
            {
                Console.WriteLine("No products in this category.");
                return;
            }
            foreach (var product in categoryData.Products)
            {
                string status = product.stockQuantity > 0 ? "Available": "Out of Stock";
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Product ID : {product.productId}");
                Console.WriteLine($"Name       : {product.productName}");
                Console.WriteLine($"Price      : {product.price}");
                Console.WriteLine($"Stock      : {product.stockQuantity}");
                Console.WriteLine($"Status     : {status}");
            }
            Console.WriteLine("-------------------------------------");
        }
        public static void ViewOrderHistory()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== View Order History ===");
            Console.ResetColor();

            // Display Users
            Console.WriteLine("Available Users:");
            foreach (var user in context.Users.ToList())
            {
                Console.WriteLine(user.userId+ " - " + user.Name);
            }

            Console.Write("Enter User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid User ID.");
                Console.ResetColor();
                return;
            }

            // Load User with Orders, OrderItems and Products
            User userData = context.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .ThenInclude(i => i.Product)
                .FirstOrDefault(u => u.userId == userId);

            if (userData == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("User not found.");
                Console.ResetColor();
                return;
            }
            if (userData.Orders.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("This user has no orders.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Order History for " + userData.Name);
            Console.ResetColor();

            foreach (var order in userData.Orders)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Order ID   : {order.orderId}");
                Console.WriteLine($"Date       : {order.orderDate}");
                Console.WriteLine($"Status     : {order.status}");
                Console.WriteLine($"Total      : {order.totalAmount}");

                Console.WriteLine("Products:");

                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine("- "+ item.Product.productName);
                    Console.WriteLine("  Quantity   : " + item.quantity);
                    Console.WriteLine("  Unit Price : " + item.unitPrice);
                    Console.WriteLine("  Subtotal   : " + item.quantity * item.unitPrice);
                }

                Console.WriteLine("-------------------------------------");
            }
        }
        public static void ProductSummaryReport()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== Product Summary Report ===");
            Console.ResetColor();

            // ---------------------------
            // Part A : Projection
            // ---------------------------

            var report = context.Products
                .Select(p => new
                {
                    ProductName = p.productName,
                    CategoryName = p.category.categoryName,
                    ReviewCount = p.Reviews.Count(),
                    AvgRating = p.Reviews.Any()? p.Reviews.Average(r => r.rating): 0,Stock = p.stockQuantity}).ToList();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product Summary");
            Console.ResetColor();

            foreach (var item in report)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Product Name : {item.ProductName}");
                Console.WriteLine($"Category     : {item.CategoryName}");
                Console.WriteLine($"Reviews      : {item.ReviewCount}");
                Console.WriteLine($"Average Rate : {item.AvgRating:F2}");
                Console.WriteLine($"Stock        : {item.Stock}");
            }

            Console.WriteLine("-------------------------------------");

            // ---------------------------
            // Part B : Lazy Loading Demo
            // ---------------------------

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Lazy Loading Demo ===");
            Console.ResetColor();
            Product product = context.Products.FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine($"Product: {product.productName}");

                // ============================================
                // SECOND SQL QUERY FIRES HERE
                // because Reviews were NOT loaded using Include()
                // ============================================

                Console.WriteLine($"Review Count: {product.Reviews.Count}");

                foreach (var review in product.Reviews)
                {
                    Console.WriteLine($"Rating: {review.rating} | Comment: {review.comment}");
                }
            }
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
                    Console.WriteLine("Invalid input.Please enter a valid number.");
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
                        PlaceOrder();
                        break;
                    case 4:
                        WriteProductReview();
                        break;
                    case 5:
                        UpdateProductPriceAndAvailability();
                        break;
                    case 6:
                        CancelOrder();
                        break;
                    case 7:
                        DeleteReview();
                        break;
                    case 8:
                        ViewAllProducts();
                        break;
                    case 9:
                        FilterProducts();
                        break;
                    case 10:
                        GetCategoryWithProducts();
                        break;
                    case 11:
                        ViewOrderHistory();
                        break;
                    case 12:
                        ProductSummaryReport();
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