using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class OrderService : IOrder
    {
        private readonly AuthenticationService authenticationService;

        public OrderService(AuthenticationService authService)
        {
            authenticationService = authService;
        }

        public void Checkout()
        {
            if (authenticationService.LoggedInCustomer == null)
            {
                Console.WriteLine("\nPlease login first.");
                return;
            }

            if (DataStore.CartItems.Count == 0)
            {
                Console.WriteLine("\nYour cart is empty.");
                return;
            }

            double subtotal = DataStore.CartItems.Sum(c => c.TotalPrice);
            double gst = subtotal * 0.18;
            double grandTotal = subtotal + gst;

            Order order = new Order
            {
                OrderId = DataStore.Orders.Count + 1001,
                OrderDate = DateTime.Now,
                Customer = authenticationService.LoggedInCustomer,
                TotalAmount = grandTotal,
                Status = "Pending Payment"
            };

            order.Items.AddRange(DataStore.CartItems);

            DataStore.Orders.Add(order);

            Console.WriteLine("\n==================================");
            Console.WriteLine("Checkout Successful");
            Console.WriteLine($"Customer : {order.Customer.Name}");
            Console.WriteLine($"Subtotal : ₹{subtotal}");
            Console.WriteLine($"GST      : ₹{gst}");
            Console.WriteLine($"Total    : ₹{grandTotal}");
            Console.WriteLine("==================================");
        }

        public void PlaceOrder()
        {
            if (DataStore.Orders.Count == 0)
            {
                Console.WriteLine("\nNo Orders Found.");
                return;
            }

            Order order = DataStore.Orders.Last();

            foreach (CartItem item in order.Items)
            {
                item.Product.Quantity -= item.Quantity;
            }

            DataStore.CartItems.Clear();

            order.Status = "Placed";

            Console.WriteLine("\nOrder Placed Successfully.");
            Console.WriteLine($"Order ID : {order.OrderId}");
        }

        public void ViewOrders()
        {
            if (authenticationService.LoggedInCustomer == null)
            {
                Console.WriteLine("Please login first.");
                return;
            }

            var customerOrders = DataStore.Orders
                .Where(o => o.Customer.CustomerId ==
                            authenticationService.LoggedInCustomer.CustomerId);

            if (!customerOrders.Any())
            {
                Console.WriteLine("\nNo Orders Found.");
                return;
            }

            Console.WriteLine("\n========== MY ORDERS ==========");

            foreach (Order order in customerOrders)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Order ID : {order.OrderId}");
                Console.WriteLine($"Date     : {order.OrderDate}");
                Console.WriteLine($"Amount   : ₹{order.TotalAmount}");
                Console.WriteLine($"Status   : {order.Status}");
            }
        }

        public void CancelOrder()
        {
            Console.Write("Enter Order ID : ");
            int id = int.Parse(Console.ReadLine()!);

            Order? order = DataStore.Orders
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                Console.WriteLine("Order Not Found.");
                return;
            }

            order.Status = "Cancelled";

            foreach (CartItem item in order.Items)
            {
                item.Product.Quantity += item.Quantity;
            }

            Console.WriteLine("\nOrder Cancelled Successfully.");
        }

        public void GenerateInvoice()
        {
            if (DataStore.Orders.Count == 0)
            {
                Console.WriteLine("No Orders Available.");
                return;
            }

            Order order = DataStore.Orders.Last();

            Console.WriteLine("\n========== INVOICE ==========");
            Console.WriteLine($"Invoice No : INV-{order.OrderId}");
            Console.WriteLine($"Customer   : {order.Customer.Name}");
            Console.WriteLine($"Date       : {order.OrderDate}");

            Console.WriteLine("\nItems");

            foreach (CartItem item in order.Items)
            {
                Console.WriteLine($"{item.Product.Name} x {item.Quantity} = ₹{item.TotalPrice}");
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Total : ₹{order.TotalAmount}");
            Console.WriteLine("=============================");
        }
    }
}