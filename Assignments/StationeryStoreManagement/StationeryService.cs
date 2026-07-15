using System;
using System.Collections.Generic;
using System.Linq;
using StationeryStoreManagement.Models;
using StationeryStoreManagement.Exceptions;
using StationeryStoreManagement.Interfaces;

namespace StationeryStoreManagement.Services
{
    public class StationeryService : IBill
    {
        // List to store all items
        private List<StationeryItem> items = new List<StationeryItem>();
       

       //==========================
       //       Add Item
       // =========================


      public void AddItem()
{
    try
    {
        Console.WriteLine("\nSelect Item Type");
        Console.WriteLine("1. Notebook");
        Console.WriteLine("2. Pen");
        Console.WriteLine("3. Marker");

        Console.Write("Enter Choice : ");
        int choice = Convert.ToInt32(Console.ReadLine());

        StationeryItem item;

        switch (choice)
        {
            case 1:
                Notebook notebook = new Notebook();

                Console.Write("Enter Pages : ");
                notebook.Pages = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Paper Type : ");
                notebook.PaperType = Console.ReadLine();

                item = notebook;
                break;

            case 2:
                Pen pen = new Pen();

                Console.Write("Enter Ink Color : ");
                pen.InkColor = Console.ReadLine();

                Console.Write("Enter Pen Type : ");
                pen.PenType = Console.ReadLine();

                item = pen;
                break;

            case 3:
                Marker marker = new Marker();

                Console.Write("Permanent (true/false) : ");
                marker.Permanent = Convert.ToBoolean(Console.ReadLine());

                item = marker;
                break;

            default:
                Console.WriteLine("Invalid Choice");
                return;
        }

        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        if (items.Any(i => i.ItemId == id))
            throw new DuplicateItemException();

        item.ItemId = id;

        Console.Write("Enter Item Name : ");
        item.ItemName = Console.ReadLine();

        Console.Write("Enter Category : ");
        item.Category = Console.ReadLine();

        Console.Write("Enter Brand : ");
        item.Brand = Console.ReadLine();

        Console.Write("Enter Price : ");
        item.Price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Quantity : ");
        item.Quantity = Convert.ToInt32(Console.ReadLine());

        items.Add(item);

        Console.WriteLine("\nItem Added Successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

        // -----------------------------
        // Display All Items
        // -----------------------------
        public void DisplayItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("\nNo Items Available.");
                return;
            }

            Console.WriteLine("\n============= ITEM LIST =============");

            foreach (StationeryItem item in items)
            {
                item.DisplayDetails();
            }
        }

        // -----------------------------
// Search Item
// -----------------------------
public void SearchItem()
{
    try
    {
        Console.WriteLine("\nSearch By");
        Console.WriteLine("1. Item ID");
        Console.WriteLine("2. Item Name");

        Console.Write("Enter Choice : ");
        int choice = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = null;

        if (choice == 1)
        {
            Console.Write("Enter Item ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            item = items.FirstOrDefault(i => i.ItemId == id);
        }
        else if (choice == 2)
        {
            Console.Write("Enter Item Name : ");
            string name = Console.ReadLine()  ?? "";

            item = items.FirstOrDefault(i =>
                i.ItemName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        if (item == null)
            throw new ItemNotFoundException();

        Console.WriteLine("\nItem Found");
        item.DisplayDetails();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}          
   
       // -----------------------------
// Update Item
// -----------------------------
public void UpdateItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Enter New Brand : ");
        item.Brand = Console.ReadLine();

        Console.Write("Enter New Price : ");
        item.Price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter New Quantity : ");
        item.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nItem Updated Successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

     // -----------------------------
// Delete Item
// -----------------------------
public void DeleteItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Delete this item? (Y/N) : ");
        char choice = Convert.ToChar(Console.ReadLine());

        if (choice == 'Y' || choice == 'y')
        {
            items.Remove(item);
            Console.WriteLine("\nItem Deleted Successfully.");
        }
        else
        {
            Console.WriteLine("\nDelete Cancelled.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

    // -----------------------------
// Generate Bill
// -----------------------------
public void GenerateBill(string itemName, double price, int quantity,
                         double discount, double gst, double total)
{
    Console.WriteLine("\n=================================");
    Console.WriteLine("           BILL");
    Console.WriteLine("=================================");
    Console.WriteLine("Item       : " + itemName);
    Console.WriteLine("Price      : " + price);
    Console.WriteLine("Quantity   : " + quantity);
    Console.WriteLine("Discount   : " + discount);
    Console.WriteLine("GST        : " + gst);
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Total      : " + total);
    Console.WriteLine("=================================");
}


// -----------------------------
// Purchase Item
// -----------------------------
public void PurchaseItem()
{
    try
    {
        Console.Write("Enter Item ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        StationeryItem item = items.FirstOrDefault(i => i.ItemId == id);

        if (item == null)
            throw new ItemNotFoundException();

        Console.Write("Enter Purchase Quantity : ");
        int purchaseQty = Convert.ToInt32(Console.ReadLine());

        if (purchaseQty > item.Quantity)
            throw new InsufficientStockException();

        double amount = item.Price * purchaseQty;

       double discountRate = 0;

if (item is Notebook)
{
    discountRate = 0.10;
}
else if (item is Pen)
{
    discountRate = 0.05;
}
else if (item is Marker)
{
    discountRate = 0.08;
}

double discount = amount * discountRate;

        double afterDiscount = amount - discount;

        double gst = afterDiscount * 0.18;

        double total = afterDiscount + gst;

        item.Quantity -= purchaseQty;

        GenerateBill(item.ItemName,
                     item.Price,
                     purchaseQty,
                     discount,
                     gst,
                     total);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
      
      // -----------------------------
// Low Stock
// -----------------------------
public void ViewLowStockItems()
{
    var lowStock = items.Where(i => i.Quantity < 5);

    if (!lowStock.Any())
    {
        Console.WriteLine("\nNo Low Stock Items.");
        return;
    }

    Console.WriteLine("\nLow Stock Items");

    foreach (var item in lowStock)
    {
        item.DisplayDetails();
    }
}


      // -----------------------------
// Sort Items
// -----------------------------
public void SortItems()
{
    Console.WriteLine("\n1. Sort By Price");
    Console.WriteLine("2. Sort By Name");
    Console.WriteLine("3. Sort By Quantity");

    Console.Write("Enter Choice : ");

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:

            items = items.OrderBy(i => i.Price).ToList();

            break;

        case 2:

            items = items.OrderBy(i => i.ItemName).ToList();

            break;

        case 3:

            items = items.OrderByDescending(i => i.Quantity).ToList();

            break;

        default:

            Console.WriteLine("Invalid Choice");
            return;
    }

    Console.WriteLine("\nItems Sorted Successfully.");

    DisplayItems();
}


    }
}