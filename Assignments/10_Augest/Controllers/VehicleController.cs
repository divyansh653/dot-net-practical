using _10_Augest.Models;
using _10_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Augest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService service;

        public VehicleController(IVehicleService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateVehicle(Vehicle vehicle)
        {
            try
            {
                return Ok(service.CreateVehicle(vehicle));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetVehicles()
        {
            return Ok(service.GetVehicles());
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicle = service.GetVehicleById(id);

            if (vehicle == null)
                return NotFound("Vehicle not found");

            return Ok(vehicle);
        }
    }
}