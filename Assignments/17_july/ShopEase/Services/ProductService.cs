using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class ProductService : IProduct
    {
       public void AddProduct()
{
    Product product = new Product();

    Console.Write("Product ID : ");
    product.ProductId = int.Parse(Console.ReadLine()!);

    if (DataStore.Products.Any(p => p.ProductId == product.ProductId))
    {
        Console.WriteLine("Product ID already exists.");
        return;
    }

    Console.Write("Product Name : ");
    product.Name = Console.ReadLine()!;

    Console.WriteLine("\nAvailable Categories");

    foreach (var category in DataStore.Categories)
    {
        Console.WriteLine($"{category.CategoryId}. {category.CategoryName}");
    }

    Console.Write("Choose Category ID : ");

    int categoryId = int.Parse(Console.ReadLine()!);

    var selectedCategory = DataStore.Categories
        .FirstOrDefault(c => c.CategoryId == categoryId);

    if (selectedCategory == null)
    {
        Console.WriteLine("Invalid Category.");
        return;
    }

    product.Category = selectedCategory.CategoryName;

    Console.Write("Description : ");
    product.Description = Console.ReadLine()!;

    Console.Write("Price : ");
    product.Price = double.Parse(Console.ReadLine()!);

    Console.Write("Quantity : ");
    product.Quantity = int.Parse(Console.ReadLine()!);

    Console.Write("Brand : ");
    product.Brand = Console.ReadLine()!;

    Console.Write("Discount : ");
    product.Discount = double.Parse(Console.ReadLine()!);

    Console.Write("Rating : ");
    product.Rating = double.Parse(Console.ReadLine()!);

    DataStore.Products.Add(product);

    Console.WriteLine("\nProduct Added Successfully.");
}
        public void ViewAllProducts()
        {
            if (DataStore.Products.Count == 0)
            {
                Console.WriteLine("\nNo Products Available.");
                return;
            }

            Console.WriteLine("\n================ PRODUCT LIST ================");

            foreach (Product product in DataStore.Products)
            {
                Console.WriteLine($"Product ID   : {product.ProductId}");
                Console.WriteLine($"Name         : {product.Name}");
                Console.WriteLine($"Category     : {product.Category}");
                Console.WriteLine($"Description  : {product.Description}");
                Console.WriteLine($"Price        : ₹{product.Price}");
                Console.WriteLine($"Quantity     : {product.Quantity}");
                Console.WriteLine($"Brand        : {product.Brand}");
                Console.WriteLine($"Discount     : {product.Discount}%");
                Console.WriteLine($"Rating       : {product.Rating}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public void SearchProduct()
        {
            Console.Write("Enter Product ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product? product = DataStore.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("\nProduct Not Found.");
                return;
            }

            Console.WriteLine("\n========== PRODUCT DETAILS ==========");
            Console.WriteLine($"ID          : {product.ProductId}");
            Console.WriteLine($"Name        : {product.Name}");
            Console.WriteLine($"Category    : {product.Category}");
            Console.WriteLine($"Description : {product.Description}");
            Console.WriteLine($"Price       : ₹{product.Price}");
            Console.WriteLine($"Quantity    : {product.Quantity}");
            Console.WriteLine($"Brand       : {product.Brand}");
            Console.WriteLine($"Discount    : {product.Discount}%");
            Console.WriteLine($"Rating      : {product.Rating}");
        }

        public void UpdateProduct()
        {
            Console.Write("Enter Product ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product? product = DataStore.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("\nProduct Not Found.");
                return;
            }

            Console.Write("Enter New Product Name : ");
            product.Name = Console.ReadLine() ?? "";

            Console.Write("Enter New Category : ");
            product.Category = Console.ReadLine() ?? "";

            Console.Write("Enter New Description : ");
            product.Description = Console.ReadLine() ?? "";

            Console.Write("Enter New Price : ");
            product.Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter New Quantity : ");
            product.Quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter New Brand : ");
            product.Brand = Console.ReadLine() ?? "";

            Console.Write("Enter New Discount : ");
            product.Discount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter New Rating : ");
            product.Rating = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nProduct Updated Successfully.");
        }

        public void DeleteProduct()
        {
            Console.Write("Enter Product ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Product? product = DataStore.Products.FirstOrDefault(p => p.ProductId == id);

            if (product == null)
            {
                Console.WriteLine("\nProduct Not Found.");
                return;
            }

            DataStore.Products.Remove(product);

            Console.WriteLine("\nProduct Deleted Successfully.");
        }

        public void SearchByCategory()
{
    Console.Write("Enter Category : ");

    string category = Console.ReadLine()!;

    var products = DataStore.Products
        .Where(p => p.Category.Equals(category,
               StringComparison.OrdinalIgnoreCase));

    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} - ₹{product.Price}");
    }
}

            public void SearchByBrand()
{
    Console.Write("Enter Brand : ");

    string brand = Console.ReadLine()!;

    var products = DataStore.Products
        .Where(p => p.Brand.Equals(brand,
               StringComparison.OrdinalIgnoreCase));

    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} - ₹{product.Price}");
    }
}
public void SortByPrice()
{
    var products = DataStore.Products
        .OrderBy(p => p.Price);

    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} - ₹{product.Price}");
    }
}
public void SortByRating()
{
    var products = DataStore.Products
        .OrderByDescending(p => p.Rating);

    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} - Rating {product.Rating}");
    }
}

public void SortByRating()
{
    var products = DataStore.Products
        .OrderByDescending(p => p.Rating);

    foreach (var product in products)
    {
        Console.WriteLine($"{product.Name} - Rating {product.Rating}");
    }
}


    }
}