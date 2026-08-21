using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService service;

        public HotelController(IHotelService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetHotels()
        {
            return Ok(service.GetAllHotels());
        }

        [HttpGet("{id}")]
        public IActionResult GetHotel(int id)
        {
            var result = service.GetHotelsById(id);

            if (result == null)
            {
                return NotFound("Hotel not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddHotel(Hotel hotel)
        {
            try
            {
                var result = service.AddHotel(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}