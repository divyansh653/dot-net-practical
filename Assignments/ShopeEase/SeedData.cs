using ShopEase.Models;

namespace ShopEase.Data
{
    public static class SeedData
    {
        public static void Initialize()
        {
            if (DataStore.Categories.Count == 0)
            {
                DataStore.Categories.Add(new Category
                {
                    CategoryId = 1,
                    CategoryName = "Electronics"
                });

                DataStore.Categories.Add(new Category
                {
                    CategoryId = 2,
                    CategoryName = "Fashion"
                });

                DataStore.Categories.Add(new Category
                {
                    CategoryId = 3,
                    CategoryName = "Books"
                });

                DataStore.Categories.Add(new Category
                {
                    CategoryId = 4,
                    CategoryName = "Home"
                });

                DataStore.Categories.Add(new Category
                {
                    CategoryId = 5,
                    CategoryName = "Sports"
                });
            }

            if (DataStore.Products.Count == 0)
            {
                DataStore.Products.Add(new Product
                {
                    ProductId = 1001,
                    Name = "Dell Inspiron Laptop",
                    Category = "Electronics",
                    Description = "Intel i5 13th Gen",
                    Price = 65000,
                    Quantity = 10,
                    Brand = "Dell",
                    Discount = 10,
                    Rating = 4.5
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1002,
                    Name = "HP Pavilion Laptop",
                    Category = "Electronics",
                    Description = "Intel i7 13th Gen",
                    Price = 72000,
                    Quantity = 8,
                    Brand = "HP",
                    Discount = 8,
                    Rating = 4.6
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1003,
                    Name = "Boat Rockerz 255",
                    Category = "Electronics",
                    Description = "Wireless Earphones",
                    Price = 1499,
                    Quantity = 25,
                    Brand = "Boat",
                    Discount = 15,
                    Rating = 4.3
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1004,
                    Name = "Logitech Keyboard",
                    Category = "Electronics",
                    Description = "Mechanical Keyboard",
                    Price = 2999,
                    Quantity = 20,
                    Brand = "Logitech",
                    Discount = 5,
                    Rating = 4.7
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1005,
                    Name = "Samsung Galaxy M36",
                    Category = "Electronics",
                    Description = "5G Smartphone",
                    Price = 19999,
                    Quantity = 15,
                    Brand = "Samsung",
                    Discount = 12,
                    Rating = 4.4
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1006,
                    Name = "Nike Running Shoes",
                    Category = "Sports",
                    Description = "Comfort Running Shoes",
                    Price = 3499,
                    Quantity = 12,
                    Brand = "Nike",
                    Discount = 20,
                    Rating = 4.6
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1007,
                    Name = "Polo T-Shirt",
                    Category = "Fashion",
                    Description = "Cotton T-Shirt",
                    Price = 899,
                    Quantity = 30,
                    Brand = "Polo",
                    Discount = 10,
                    Rating = 4.2
                });

                DataStore.Products.Add(new Product
                {
                    ProductId = 1008,
                    Name = "Atomic Habits",
                    Category = "Books",
                    Description = "Self Improvement Book",
                    Price = 499,
                    Quantity = 18,
                    Brand = "Penguin",
                    Discount = 5,
                    Rating = 4.9
                });
            }
        }
    }
}