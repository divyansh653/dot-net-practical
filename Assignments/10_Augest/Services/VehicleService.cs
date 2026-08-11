using _10_Augest.Data;
using _10_Augest.Models;

namespace _10_Augest.Repository
{
    public class VehicleService : IVehicleService
    {
        private readonly AppDbContext context;

        public VehicleService(AppDbContext context)
        {
            this.context = context;
        }

        public Vehicle CreateVehicle(Vehicle vehicle)
        {
            var company = context.Companies
                .FirstOrDefault(c => c.Id == vehicle.CompanyId);

            if (company == null)
                throw new ArgumentException("Invalid Company");

            var vehicleAlreadyExists = context.Vehicles.Any(v =>
                v.CompanyId == vehicle.CompanyId &&
                v.VehicleName == vehicle.VehicleName);

            if (vehicleAlreadyExists)
                throw new ArgumentException("Vehicle already exists");

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            return vehicle;
        }

        public List<Vehicle> GetVehicles()
        {
            return context.Vehicles.ToList();
        }

        public Vehicle? GetVehicleById(int id)
        {
            return context.Vehicles.FirstOrDefault(v => v.Id == id);
        }
    }
}