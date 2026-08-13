using HotelBookingAPI.Models;
using System.ComponentModel.DataAnnotations;

public class Room
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Enter the Hote Id ")]
    [Range(1,5)]
    public int HotelId { get; set; }
    [Required(ErrorMessage ="Enter the Room Number")]
    [Range(1,6)]
    public int RoomNumber { get; set; }

    [Required(ErrorMessage = "Enter the Room Type")]
    [StringLength(20, ErrorMessage = "RoomType can't be exceed 20 letters")]
    public string RoomType { get; set; } = string.Empty;
    [Required(ErrorMessage ="Enter the Price of rooms")]
    public decimal Price { get; set; }

    public Hotel? Hotel { get; set; }

    public ICollection<BookingRoom>? BookingRooms { get; set; }
}