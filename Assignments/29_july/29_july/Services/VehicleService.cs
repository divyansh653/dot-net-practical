using _29_july.Models;

namespace _29_july.Services
{
    public class VehicleService : IVehicleService
    {
        private static List<Vehicle> vehicles = new List<Vehicle>()
        {
            new Vehicle
            {
                Id = 1,
                VehicleName = "Creta",
                Brand = "Hyundai",
                Model = "SX",
                Year = 2024,
                Price = 1800000
            },
            new Vehicle
            {
                Id = 2,
                VehicleName = "Nexon",
                Brand = "Tata",
                Model = "XZ+",
                Year = 2023,
                Price = 1400000
            },
            new Vehicle
            {
                Id = 3,
                VehicleName = "City",
                Brand = "Honda",
                Model = "ZX",
                Year = 2024,
                Price = 1500000
            },
            new Vehicle
            {
                Id = 4,
                VehicleName = "Scorpio",
                Brand = "Mahindra",
                Model = "N",
                Year = 2025,
                Price = 2200000
            }
        };

        public List<Vehicle> getVehicles()
        {
            return vehicles;
        }

        public Vehicle getVehicle(int id)
        {
            return vehicles.FirstOrDefault(v => v.Id == id);
        }

        public Vehicle getVehicleName(string vehicleName)
        {
            return vehicles.FirstOrDefault(v => v.VehicleName == vehicleName);
        }

        public Vehicle addVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            return vehicle;
        }
    }
}