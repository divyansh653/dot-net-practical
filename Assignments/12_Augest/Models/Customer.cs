using HotelBookingAPI.Models;
using System.ComponentModel.DataAnnotations;
namespace HotelBookingAPI.Models;

public class Customer
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enetr the Name ")]
    [StringLength(20, ErrorMessage = "name cant be above the 20 letters")]
    public string Name { get; set; } = String.Empty;

    [Required(ErrorMessage ="Enter the Email Address ")]
    [EmailAddress]
    public string Email { get; set; }= String.Empty;

    public ICollection<Booking>? Bookings { get; set; }
}