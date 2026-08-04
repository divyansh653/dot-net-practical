using ShopEase.Data;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class ReportService
    {
        public void ShowReport()
        {
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("           SHOPEASE REPORT");
            Console.WriteLine("===========================================");

            Console.WriteLine($"Total Customers   : {DataStore.Customers.Count}");
            Console.WriteLine($"Total Categories  : {DataStore.Categories.Count}");
            Console.WriteLine($"Total Products    : {DataStore.Products.Count}");
            Console.WriteLine($"Items In Cart     : {DataStore.CartItems.Count}");
            Console.WriteLine($"Total Orders      : {DataStore.Orders.Count}");
            Console.WriteLine($"Total Payments    : {DataStore.Payments.Count}");

            double revenue = DataStore.Payments.Sum(p => p.Amount);

            Console.WriteLine($"Total Revenue     : ₹{revenue}");

            Console.WriteLine();
            Console.WriteLine("========== PRODUCT STOCK ==========");

            if (DataStore.Products.Count == 0)
            {
                Console.WriteLine("No Products Available.");
            }
            else
            {
                foreach (Product product in DataStore.Products)
                {
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine($"Product ID : {product.ProductId}");
                    Console.WriteLine($"Name       : {product.Name}");
                    Console.WriteLine($"Stock      : {product.Quantity}");
                }
            }

            Console.WriteLine("===========================================");
        }
    }
}