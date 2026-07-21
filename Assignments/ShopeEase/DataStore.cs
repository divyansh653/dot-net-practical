using ShopEase.Models;
using System.Collections.Generic;

namespace ShopEase.Data
{
    public static class DataStore
    {
        public static List<Customer> Customers { get; } = new();

        public static List<Product> Products { get; } = new();

        public static List<Category> Categories { get; } = new();

        public static List<CartItem> CartItems { get; } = new();

        public static List<Order> Orders { get; } = new();

        public static List<Payment> Payments { get; } = new();
    }
}