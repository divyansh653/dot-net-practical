using HotelBookingAPI.Models;
using HotelBookingAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBooking(BookingRequest request)
    {
        try
        {
            var booking = await _bookingService.CreateBooking(
                request.CustomerId,
                request.RoomIds,
                request.Checkin,
                request.Checkout);

            return Ok(booking);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetBookingsByCustomerId(int customerId)
    {
        var bookings = await _bookingService
            .GetBookingsByCustomerId(customerId);

        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var booking = await _bookingService.GetBookingById(id);

        if (booking == null)
        {
            return NotFound("Booking not found");
        }

        return Ok(booking);
    }


    [HttpPut("cancel/{id}")]
    public async Task<IActionResult> CancelBooking(int id)
    {
        var result = await _bookingService.CancelBooking(id);

        if (!result)
        {
            return BadRequest("Booking not found or already cancelled");
        }

        return Ok("Booking cancelled successfully");
    }
}