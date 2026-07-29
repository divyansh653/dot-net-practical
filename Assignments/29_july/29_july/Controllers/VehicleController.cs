using Microsoft.AspNetCore.Mvc;
using _29_july.Models;
using _29_july.Services;

namespace _29_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public ActionResult<List<Vehicle>> GetVehicles()
        {
            return Ok(_vehicleService.getVehicles());
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int id)
        {
            return Ok(_vehicleService.getVehicle(id));
        }

        [HttpGet("name/{vehicleName}")]
        public ActionResult<Vehicle> GetVehicleName(string vehicleName)
        {
            return Ok(_vehicleService.getVehicleName(vehicleName));
        }

        [HttpPost]
        public ActionResult<Vehicle> AddVehicle(Vehicle vehicle)
        {
            return Ok(_vehicleService.addVehicle(vehicle));
        }
    }
}