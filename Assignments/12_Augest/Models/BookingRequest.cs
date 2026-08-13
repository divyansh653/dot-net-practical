namespace HotelBookingAPI.Models;

public class BookingRequest
{
    public int CustomerId { get; set; }

    public List<int> RoomIds { get; set; }

    public DateTime Checkin { get; set; }

    public DateTime Checkout { get; set; }
}