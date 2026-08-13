using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _hotelService;

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHotels()
    {
        var hotels = await _hotelService.GetAllHotels();

        return Ok(hotels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        var hotel = await _hotelService.GetHotelById(id);

        if (hotel == null)
        {
            return NotFound("Hotel not found");
        }

        return Ok(hotel);
    }

    [HttpPost]
    public async Task<IActionResult> AddHotel(Hotel hotel)
    {
        var result = await _hotelService.AddHotel(hotel);

        return Ok(result);
    }
}