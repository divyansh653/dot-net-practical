using System;

namespace AutomobileManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name : ");
            string name = Console.ReadLine() !;

            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nWelcome {name}");

            VehicleManager manager = new VehicleManager();

            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("ABC MOTORS");
                Console.WriteLine("Vehicle Management System");
                Console.WriteLine("==============================");

                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View All Vehicles");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle Price");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Calculate Discount");
                Console.WriteLine("7. Show Vehicle Details");
                Console.WriteLine("8. Exit");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddVehicle();
                        break;

                    case 2:
                        manager.ViewVehicles();
                        break;

                    case 3:
                        manager.SearchVehicle();
                        break;

                    case 4:
                        manager.UpdatePrice();
                        break;

                    case 5:
                        manager.DeleteVehicle();
                        break;

                    case 6:
                        manager.CalculateDiscount();
                        break;

                    case 7:
                        manager.ShowVehicleDetails();
                        break;

                    case 8:
                        Console.WriteLine("Thank you for using ABC Motors System.");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}