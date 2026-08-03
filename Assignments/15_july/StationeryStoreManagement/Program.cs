using System;
using StationeryStoreManagement.Services;
using StationeryStoreManagement.Exceptions;

namespace StationeryStoreManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "admin";
            string password = "admin123";

            int attempts = 3;
            bool loginSuccess = false;

            Console.WriteLine("=========================================");
            Console.WriteLine(" Stationery Store Management System");
            Console.WriteLine("=========================================");

            while (attempts > 0)
            {
                Console.Write("\nEnter Username : ");
                string user = Console.ReadLine()  ?? "";

                Console.Write("Enter Password : ");
                string pass = Console.ReadLine()  ?? "";

                if (user == username && pass == password)
                {
                    loginSuccess = true;
                    Console.WriteLine("\nLogin Successful!");
                    break;
                }
                else
                {
                    attempts--;

                    if (attempts > 0)
                    {
                        Console.WriteLine("\nInvalid Login");
                        Console.WriteLine("Attempts Left : " + attempts);
                    }
                }
            }

            try
            {
                if (!loginSuccess)
                {
                    throw new LoginFailedException();
                }

                StationeryService service = new StationeryService();

                int choice;

                do
                {
                    Console.Clear();

                    Console.WriteLine("=========================================");
                    Console.WriteLine(" Stationery Store Management System");
                    Console.WriteLine("=========================================");

                    Console.WriteLine("1. Add Stationery Item");
                    Console.WriteLine("2. Display All Items");
                    Console.WriteLine("3. Search Item");
                    Console.WriteLine("4. Update Item");
                    Console.WriteLine("5. Delete Item");
                    Console.WriteLine("6. Purchase Item");
                    Console.WriteLine("7. View Low Stock Items");
                    Console.WriteLine("8. Sort Items");
                    Console.WriteLine("9. Exit");

                    Console.Write("\nEnter Choice : ");

                    choice = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine();

                    switch (choice)
                    {
                        case 1:
                            service.AddItem();
                            break;

                        case 2:
                            service.DisplayItems();
                            break;

                        case 3:
                            service.SearchItem();
                            break;

                        case 4:
                            service.UpdateItem();
                            break;

                        case 5:
                            service.DeleteItem();
                            break;

                        case 6:
                            service.PurchaseItem();
                            break;

                        case 7:
                            service.ViewLowStockItems();
                            break;

                        case 8:
                            service.SortItems();
                            break;

                        case 9:
                            Console.WriteLine("\nThank You!");
                            Console.WriteLine("Visit Again...");
                            break;

                        default:
                            Console.WriteLine("Invalid Choice!");
                            break;
                    }

                    if (choice != 9)
                    {
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                    }

                } while (choice != 9);
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine("\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError : " + ex.Message);
            }
        }
    }
}