using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class CartService : ICart
    {
        public void AddToCart()
        {
            if (DataStore.Products.Count == 0)
            {
                Console.WriteLine("\nNo Products Available.");
                return;
            }

            Console.WriteLine("\n========== AVAILABLE PRODUCTS ==========");

            foreach (Product product in DataStore.Products)
            {
                Console.WriteLine($"{product.ProductId} - {product.Name} - ₹{product.Price} - Stock : {product.Quantity}");
            }

            Console.Write("\nEnter Product ID : ");
            int productId = Convert.ToInt32(Console.ReadLine());

            Product? product = DataStore.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null)
            {
                Console.WriteLine("Product Not Found.");
                return;
            }

            Console.Write("Enter Quantity : ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity > product.Quantity)
            {
                Console.WriteLine("Insufficient Stock.");
                return;
            }

            CartItem? existingItem = DataStore.CartItems
                .FirstOrDefault(c => c.Product.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                CartItem item = new CartItem();

                item.Product = product;
                item.Quantity = quantity;

                DataStore.CartItems.Add(item);
            }

            Console.WriteLine("\nProduct Added To Cart Successfully.");
        }

        public void ViewCart()
        {
            if (DataStore.CartItems.Count == 0)
            {
                Console.WriteLine("\nCart is Empty.");
                return;
            }

            double total = 0;

            Console.WriteLine("\n================ YOUR CART ================");

            foreach (CartItem item in DataStore.CartItems)
            {
                Console.WriteLine($"ID       : {item.Product.ProductId}");
                Console.WriteLine($"Name     : {item.Product.Name}");
                Console.WriteLine($"Price    : ₹{item.Product.Price}");
                Console.WriteLine($"Quantity : {item.Quantity}");
                Console.WriteLine($"Total    : ₹{item.TotalPrice}");
                Console.WriteLine("------------------------------------------");

                total += item.TotalPrice;
            }

            Console.WriteLine($"Cart Total : ₹{total}");
        }

        public void RemoveFromCart()
        {
            Console.Write("Enter Product ID : ");

            int id = Convert.ToInt32(Console.ReadLine());

            CartItem? item = DataStore.CartItems
                .FirstOrDefault(c => c.Product.ProductId == id);

            if (item == null)
            {
                Console.WriteLine("Product Not Found.");
                return;
            }

            DataStore.CartItems.Remove(item);

            Console.WriteLine("\nItem Removed Successfully.");
        }

        public void UpdateQuantity()
        {
            Console.Write("Enter Product ID : ");

            int id = Convert.ToInt32(Console.ReadLine());

            CartItem? item = DataStore.CartItems
                .FirstOrDefault(c => c.Product.ProductId == id);

            if (item == null)
            {
                Console.WriteLine("Product Not Found.");
                return;
            }

            Console.Write("Enter New Quantity : ");

            int quantity = Convert.ToInt32(Console.ReadLine());

            if (quantity > item.Product.Quantity)
            {
                Console.WriteLine("Insufficient Stock.");
                return;
            }

            item.Quantity = quantity;

            Console.WriteLine("\nQuantity Updated Successfully.");
        }

        public void ClearCart()
        {
            DataStore.CartItems.Clear();

            Console.WriteLine("\nCart Cleared Successfully.");
        }

        public void ApplyCoupon()
        {
            if (DataStore.CartItems.Count == 0)
            {
                Console.WriteLine("Cart is Empty.");
                return;
            }

            double total = DataStore.CartItems.Sum(c => c.TotalPrice);

            Console.Write("Enter Coupon Code : ");

            string coupon = Console.ReadLine() ?? "";

            double discount = 0;

            if (coupon.Equals("SAVE10", StringComparison.OrdinalIgnoreCase))
            {
                discount = total * 0.10;
            }

            double subtotal = total - discount;
            double gst = subtotal * 0.18;
            double grandTotal = subtotal + gst;

            Console.WriteLine("\n============== BILL ==============");
            Console.WriteLine($"Total         : ₹{total}");
            Console.WriteLine($"Discount      : ₹{discount}");
            Console.WriteLine($"GST (18%)     : ₹{gst}");
            Console.WriteLine($"Grand Total   : ₹{grandTotal}");
        }
    }
}