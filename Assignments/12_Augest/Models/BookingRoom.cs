using System.ComponentModel.DataAnnotations;
namespace HotelBookingAPI.Models;

public class BookingRoom
{
    [Required(ErrorMessage ="Enter the Booking id")]

    public int BookingId { get; set; }

    [Required(ErrorMessage ="Enter the Room Id ")]
    public int RoomId { get; set; }

    [Required(ErrorMessage ="Enter the Price")]
    public decimal Price { get; set; }

    public Booking? Booking { get; set; }

    public Room? Room { get; set; }
}