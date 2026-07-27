using ECommerceDatabase;
using ECommerceDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EECommerceDatabase
{
    public class Program
    {
        private static ProjectContext context = new ProjectContext();
        static int loggedInUserId = 0;
        public static void Main(string[] args)
        {
            

                bool exitApp = false;
                while (!exitApp) 
                {
                    Console.WriteLine("\n===== E-Commerce Console App =====");
                    Console.WriteLine(" 1. Register New User");
                    Console.WriteLine(" 2. Login");
                    Console.WriteLine(" 3. Add New Category");
                    Console.WriteLine(" 4. Add New Product");
                    Console.WriteLine(" 5. View All Products");
                    Console.WriteLine(" 6. Place an Order");
                    Console.WriteLine(" 7. View My Orders");
                    Console.WriteLine(" 8. View Order Details");
                    Console.WriteLine(" 9. Add a Review for an Order");
                    Console.WriteLine("10. View All Reviews for a Product");
                    Console.WriteLine("11. Logout");
                    Console.WriteLine(" 0. Exit");
                    Console.Write("Enter your choice: ");

                    int choice;
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                        continue;
                    }

                    switch (choice) 
                    {
                    case 1: RegisterUser(); break;
                    case 2: Login(); break;
                    case 3: AddCategory(); break;
                    case 4: AddProduct(); break;
                    case 5: ViewAllProducts(); break;
                    case 6: PlaceOrder(); break;
                    case 7: ViewMyOrders(); break;
                    case 8: ViewOrderDetails(); break;
                    case 9: AddReview(); break;
                    case 10: ViewReviewsForProduct(); break;
                    case 11: Logout(); break;
                    case 0:
                        exitApp = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                }
            }
        static void RegisterUser()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = new User { UserName = name, UserEmail = email, UserPassword = password };
            context.Users.Add(user);
            context.SaveChanges();

            Console.WriteLine($"User registered with Id {user.UserId}");
        }

        static void Login()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var user = context.Users.FirstOrDefault(u => u.UserEmail == email && u.UserPassword == password);
            if (user == null)
            {
                Console.WriteLine("Invalid email or password.");
                return;
            }

            loggedInUserId = user.UserId;
            Console.WriteLine($"Logged in as {user.UserName}");
        }

        static void AddCategory()
        {
            Console.Write("Category name: ");
            string name = Console.ReadLine();

            context.Categories.Add(new Category { CategoryName = name });
            context.SaveChanges();

            Console.WriteLine("Category added.");
        }

        static void AddProduct()
        {
            var categories = context.Categories.ToList();
            if (!categories.Any())
            {
                Console.WriteLine("No categories exist. Add a category first.");
                return;
            }

            Console.WriteLine("Categories:");
            foreach (var c in categories)
                Console.WriteLine($"{c.CategoryId}. {c.CategoryName}");

            Console.Write("Product name: ");
            string name = Console.ReadLine();
            Console.Write("Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Category Id: ");
            int categoryId = int.Parse(Console.ReadLine());

            if (!categories.Any(c => c.CategoryId == categoryId))
            {
                Console.WriteLine("Invalid category Id.");
                return;
            }

            context.Products.Add(new Product { ProductName = name, ProductPrice = price, CategoryId = categoryId });
            context.SaveChanges();

            Console.WriteLine("Product added.");
        }

        static void ViewAllProducts()
        {
            Console.Write("Filter by Category Id (leave blank for all): ");
            string input = Console.ReadLine();

            var query = context.Products.Include(p => p.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(input))
            {
                int categoryId = int.Parse(input);
                query = query.Where(p => p.CategoryId == categoryId);
            }

            var products = query.ToList();
            if (!products.Any())
            {
                Console.WriteLine("No products found.");
                return;
            }

            foreach (var p in products)
                Console.WriteLine($"{p.ProductId}. {p.ProductName} - {p.ProductPrice:C} - {p.Category.CategoryName}");
        }

        static void PlaceOrder()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to place an order.");
                return;
            }

            var order = new Order { UserId = loggedInUserId, OrderDate = DateTime.Now };
            context.Orders.Add(order);
            context.SaveChanges();

            bool addingProducts = true;
            while (addingProducts)
            {
                var products = context.Products.ToList();
                Console.WriteLine("Products:");
                foreach (var p in products)
                    Console.WriteLine($"{p.ProductId}. {p.ProductName} - {p.ProductPrice:C}");

                Console.Write("Product Id: ");
                int productId = int.Parse(Console.ReadLine());

                if (!products.Any(p => p.ProductId == productId))
                {
                    Console.WriteLine("Invalid product Id.");
                    continue;
                }

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                context.OrderProducts.Add(new OrderProduct
                {
                    OrderId = order.OrderId,
                    ProductId = productId,
                    Quantity = quantity
                });
                context.SaveChanges();

                Console.Write("Add another product? (y/n): ");
                addingProducts = Console.ReadLine().Trim().ToLower() == "y";
            }

            Console.WriteLine($"Order {order.OrderId} placed.");
        }

        static void ViewMyOrders()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to view your orders.");
                return;
            }

            var orders = context.Orders.Where(o => o.UserId == loggedInUserId).ToList();
            if (!orders.Any())
            {
                Console.WriteLine("You have no orders.");
                return;
            }

            foreach (var o in orders)
                Console.WriteLine($"Order {o.OrderId} - {o.OrderDate}");
        }

        static void ViewOrderDetails()
        {
            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders
                .Include(o => o.OrderProducts)
                    .ThenInclude(op => op.Product)
                .Include(o => o.Review)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Console.WriteLine($"Order {order.OrderId} - {order.OrderDate}");

            decimal total = 0;
            foreach (var op in order.OrderProducts)
            {
                decimal lineTotal = op.Product.ProductPrice * op.Quantity;
                total += lineTotal;
                Console.WriteLine($"{op.Product.ProductName} x {op.Quantity} = {lineTotal:C}");
            }

            Console.WriteLine($"Total: {total:C}");

            if (order.Review != null)
                Console.WriteLine($"Review: {order.Review.ReviewRating}/5 - {order.Review.ReviewComment}");
            else
                Console.WriteLine("No review yet.");
        }

        static void AddReview()
        {
            if (loggedInUserId == 0)
            {
                Console.WriteLine("You must be logged in to add a review.");
                return;
            }

            Console.Write("Order Id: ");
            int orderId = int.Parse(Console.ReadLine());

            var order = context.Orders.Include(o => o.Review).FirstOrDefault(o => o.OrderId == orderId);

            if (order == null || order.UserId != loggedInUserId)
            {
                Console.WriteLine("Order not found or does not belong to you.");
                return;
            }

            if (order.Review != null)
            {
                Console.WriteLine("This order already has a review.");
                return;
            }

            Console.Write("Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());
            Console.Write("Comment: ");
            string comment = Console.ReadLine();

            context.Reviews.Add(new Review { OrderId = orderId, ReviewRating = rating, ReviewComment = comment });
            context.SaveChanges();

            Console.WriteLine("Review added.");
        }

        static void ViewReviewsForProduct()
        {
            Console.Write("Product Id: ");
            int productId = int.Parse(Console.ReadLine());

            var orders = context.OrderProducts
                .Where(op => op.ProductId == productId)
                .Include(op => op.Order)
                    .ThenInclude(o => o.Review)
                .Select(op => op.Order)
                .Distinct()
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("No orders found for this product.");
                return;
            }

            foreach (var o in orders)
            {
                if (o.Review != null)
                    Console.WriteLine($"Order {o.OrderId}: {o.Review.ReviewRating}/5 - {o.Review.ReviewComment}");
                else
                    Console.WriteLine($"Order {o.OrderId}: No review.");
            }
        }

        static void Logout()
        {
            loggedInUserId = 0;
            Console.WriteLine("Logged out.");
        }
    }
}