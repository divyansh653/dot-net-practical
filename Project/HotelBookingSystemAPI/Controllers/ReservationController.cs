using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBookingSystem.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService service;

        public ReservationController(IReservationService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            var result = service.GetReservationByID(id);
            if (result == null)
            {
                return NotFound("Reservation not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddReservation(Reservation r)
        {
            try
            {
                var customerId =
                    User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(customerId))
                {
                    return Unauthorized("Customer ID not found.");
                }

                r.CustomerId = int.Parse(customerId);

                var result = service.AddReservation(r);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult CancelReservation(int id)
        {
            var answer = service.GetReservationByID(id);
            if (answer != null)
            {
                service.DeleteReservation(id);
                return Ok("Cancelled successfully.");
            }
            return BadRequest("Not found");
        }
    }
}