using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRooms()
    {
        var rooms = await _roomService.GetAllRooms();

        return Ok(rooms);
    }

    [HttpGet("hotel/{hotelId}")]
    public async Task<IActionResult> GetRoomsByHotelId(int hotelId)
    {
        var rooms = await _roomService.GetRoomsByHotelId(hotelId);

        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById(int id)
    {
        var room = await _roomService.GetRoomById(id);

        if (room == null)
        {
            return NotFound("Room not found");
        }

        return Ok(room);
    }

    [HttpPost]
    public async Task<IActionResult> AddRoom(Room room)
    {
        var result = await _roomService.AddRoom(room);

        return Ok(result);
    }
}