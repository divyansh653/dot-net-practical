using _10_Augest.Models;
using _10_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Augest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            try
            {
                return Ok(service.CreateCustomer(customer));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCustomers()
        {
            return Ok(service.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = service.GetCustomerById(id);

            if (customer == null)
                return NotFound("Customer not found");

            return Ok(customer);
        }
    }
}