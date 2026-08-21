using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            var result = service.GetCustomers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel(int id)
        {
            var result = service.GetCustomer(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddHotel(Customer c)
        {
            var result = service.AddCustomer(c);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateCustomer(Customer c, int id)
        {
            var result = service.UpdateCustomer(c, id);

            if (result == null)
            {
                return BadRequest("No any room found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCustomer(int id)
        {
            var answer = service.GetCustomer(id);

            if (answer != null)
            {
                service.DeleteCustomer(id);

                return Ok("Deleted Successfully");
            }

            return BadRequest("Not found");
        }
    }
}
