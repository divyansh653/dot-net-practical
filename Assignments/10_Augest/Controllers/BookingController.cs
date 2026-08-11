using _10_Augest.Models;
using _10_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Augest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService service;

        public BookingController(IBookingService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking booking)
        {
            try
            {
                return Ok(service.CreateBooking(booking));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            return Ok(service.GetBookings());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = service.GetBookingById(id);

            if (booking == null)
                return NotFound("Booking not found");

            return Ok(booking);
        }
    }
}