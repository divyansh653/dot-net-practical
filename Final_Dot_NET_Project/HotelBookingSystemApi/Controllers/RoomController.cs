using HotelBookingSystem.Models;
using HotelBookingSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingSystem.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService service;

        public RoomController(IRoomService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult ShowAllRoom()
        {
            return Ok(service.GetRooms());
        }

        [HttpGet("Hotel/{hotelId}")]
        public IActionResult GetRoomsByHotel(int hotelId)
        {
            return Ok(service.GetRoomsByHotelId(hotelId));
        }

        [HttpGet("{id}")]
        public IActionResult Getrooms(int id)
        {
            var result = service.GetRoomById(id);
            if (result == null)
            {
                return NotFound("Room not found.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRoom(Room room)
        {
            try
            {
                return Ok(service.AddRoom(room));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Updateroom(Room room, int id)
        {
            var result = service.UpdateRoom(room, id);
            if (result == null)
            {
                return BadRequest("No room found.");
            }
            return Ok(result);
        }

        [HttpGet("Type/{type}")]
        public IActionResult Filter(string type)
        {
            try
            {
                return Ok(service.GetroomsByType(type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
