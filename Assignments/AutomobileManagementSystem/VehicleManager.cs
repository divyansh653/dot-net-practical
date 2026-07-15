using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileManagementSystem
{
    public class VehicleManager
    {
        List<Vehicle> vehicles = new List<Vehicle>();

       //============================
       //    ADD VEHICLES
       //==============================

        public void AddVehicle()
{
    Vehicle vehicle = new Vehicle();

    Console.Write("Enter Vehicle ID : ");
    vehicle.VehicleId = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter Vehicle Name : ");
    vehicle.VehicleName = Console.ReadLine()!;

    Console.Write("Enter Vehicle Type : ");
    vehicle.VehicleType = Console.ReadLine()!;

    Console.Write("Enter Brand : ");
    vehicle.Brand = Console.ReadLine()!;

    Console.Write("Enter Price : ");
    vehicle.Price = Convert.ToDouble(Console.ReadLine());

    Console.Write("Enter Manufacturing Year : ");
    vehicle.ManufacturingYear = Convert.ToInt32(Console.ReadLine());

    vehicles.Add(vehicle);

    Console.WriteLine("\nVehicle Added Successfully.");
}

          //===============================
          //      VIEW VEHICLES
          //====================================
public void ViewVehicles()
{
    if (vehicles.Count == 0)
    {
        Console.WriteLine("No Vehicles Available.");
        return;
    }

    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("ID\tName\tBrand\tType\tPrice");
    Console.WriteLine("-----------------------------------------------");

    foreach (Vehicle v in vehicles)
    {
        Console.WriteLine($"{v.VehicleId}\t{v.VehicleName}\t{v.Brand}\t{v.VehicleType}\t{v.Price}");
    }
}

      //=================================
      //       SEARCH VEHICLES
      //====================================
public void SearchVehicle()
{
    Console.Write("Enter Vehicle ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Vehicle? vehicle = vehicles.Find(v => v.VehicleId == id);

    if (vehicle != null)
    {
        Console.WriteLine("Vehicle Found");
        Console.WriteLine("Name : " + vehicle.VehicleName);
        Console.WriteLine("Brand : " + vehicle.Brand);
        Console.WriteLine("Type : " + vehicle.VehicleType);
        Console.WriteLine("Price : " + vehicle.Price);
        Console.WriteLine("Year : " + vehicle.ManufacturingYear);
    }
    else
    {
        Console.WriteLine("Vehicle Not Found");
    }
}

     //==============================
     //       UPDATE PRICE
     //=======================================

public void UpdatePrice()
{
    Console.Write("Enter Vehicle ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Vehicle? vehicle = vehicles.Find(v => v.VehicleId == id);

    if (vehicle != null)
    {
        Console.Write("Enter New Price : ");
        vehicle.Price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Price Updated Successfully.");
    }
    else
    {
        Console.WriteLine("Vehicle ID does not exist.");
    }
}

           //===================================
           //         DELETE VEHICLES
           //========================================
public void DeleteVehicle()
{
    Console.Write("Enter Vehicle ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Vehicle? vehicle = vehicles.Find(v => v.VehicleId == id);

    if (vehicle != null)
    {
        vehicles.Remove(vehicle);

        Console.WriteLine("Vehicle Deleted Successfully.");
    }
    else
    {
        Console.WriteLine("Vehicle not available.");
    }
}

        //========================================
        //        CALCULATE DISCOUNT
        //==========================================

public void CalculateDiscount()
{
    Console.Write("Enter Vehicle ID : ");
    int id = Convert.ToInt32(Console.ReadLine());

    Vehicle? vehicle = vehicles.Find(v => v.VehicleId == id);

    if (vehicle != null)
    {
        double discount = 0;

        if (vehicle.VehicleType.ToLower() == "car")
            discount = vehicle.Price * 0.10;

        else if (vehicle.VehicleType.ToLower() == "bike")
            discount = vehicle.Price * 0.05;

        else if (vehicle.VehicleType.ToLower() == "truck")
            discount = vehicle.Price * 0.12;

        Console.WriteLine("Vehicle Price : " + vehicle.Price);
        Console.WriteLine("Discount : " + discount);
        Console.WriteLine("Final Price : " + (vehicle.Price - discount));
    }
    else
    {
        Console.WriteLine("Vehicle Not Found");
    }
}

            //=====================================
            //       SHOW VEHICLES DETAILS
            //============================================
            
public void ShowVehicleDetails()
{
    Console.Write("Enter Vehicle Type : ");
    string type = (Console.ReadLine() ?? "").ToLower();

    switch (type)
    {
        case "car":
            Console.WriteLine("Car is a four wheeler.");
            Console.WriteLine("Suitable for family.");
            break;

        case "bike":
            Console.WriteLine("Bike is fuel efficient.");
            Console.WriteLine("Suitable for city rides.");
            break;

        case "truck":
            Console.WriteLine("Truck is used for transportation.");
            Console.WriteLine("Heavy load vehicle.");
            break;

        default:
            Console.WriteLine("Invalid Vehicle Type");
            break;
    }
}

}
}
