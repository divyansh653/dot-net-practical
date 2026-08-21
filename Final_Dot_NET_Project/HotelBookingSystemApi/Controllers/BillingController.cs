using HotelBookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService service;

        public BillingController(IBillingService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetBills()
        {
            return Ok(service.GetBillingList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBillById(int id)
        {
            var result = service.GetBilling(id);
            if (result == null)
            {
                return NotFound("Bill not found.");
            }
            return Ok(result);
        }

        [HttpPost("{reservationId}")]
        public IActionResult CreateBill(int reservationId)
        {
            try
            {
                return Ok(service.CreateBill(reservationId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult MakePayment(int id)
        {
            try
            {
                return Ok(service.MakePayment(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}