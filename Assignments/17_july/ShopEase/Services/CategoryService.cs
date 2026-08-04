using ShopEase.Data;
using ShopEase.Interfaces;
using ShopEase.Models;
using System;
using System.Linq;

namespace ShopEase.Services
{
    public class CategoryService : ICategory
    {
        public void AddCategory()
        {
            Category category = new Category();

            Console.Write("Enter Category ID : ");
            category.CategoryId = Convert.ToInt32(Console.ReadLine());

            if (DataStore.Categories.Any(c => c.CategoryId == category.CategoryId))
            {
                Console.WriteLine("Category ID already exists.");
                return;
            }

            Console.Write("Enter Category Name : ");
            category.CategoryName = Console.ReadLine() ?? "";

            DataStore.Categories.Add(category);

            Console.WriteLine("\nCategory Added Successfully.");
        }

        public void UpdateCategory()
        {
            Console.Write("Enter Category ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Category? category = DataStore.Categories
                                          .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                Console.WriteLine("\nCategory Not Found.");
                return;
            }

            Console.Write("Enter New Category Name : ");
            category.CategoryName = Console.ReadLine() ?? "";

            Console.WriteLine("\nCategory Updated Successfully.");
        }

        public void DeleteCategory()
        {
            Console.Write("Enter Category ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Category? category = DataStore.Categories
                                          .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                Console.WriteLine("\nCategory Not Found.");
                return;
            }

            DataStore.Categories.Remove(category);

            Console.WriteLine("\nCategory Deleted Successfully.");
        }

        public void ViewCategories()
        {
            if (DataStore.Categories.Count == 0)
            {
                Console.WriteLine("\nNo Categories Available.");
                return;
            }

            Console.WriteLine("\n========== CATEGORY LIST ==========");

            foreach (Category category in DataStore.Categories)
            {
                Console.WriteLine($"Category ID   : {category.CategoryId}");
                Console.WriteLine($"Category Name : {category.CategoryName}");
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}