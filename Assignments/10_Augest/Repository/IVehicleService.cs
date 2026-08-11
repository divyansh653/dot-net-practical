using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public interface IVehicleService
    {
        Vehicle CreateVehicle(Vehicle vehicle);

        List<Vehicle> GetVehicles();

        Vehicle? GetVehicleById(int id);
    }
}