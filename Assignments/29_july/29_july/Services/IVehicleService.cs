using _29_july.Models;

namespace _29_july.Services
{
    public interface IVehicleService
    {
        List<Vehicle> getVehicles();

        Vehicle? getVehicle(int id);

        Vehicle? getVehicleName(string vehicleName);

        Vehicle addVehicle(Vehicle vehicle);
    }
}