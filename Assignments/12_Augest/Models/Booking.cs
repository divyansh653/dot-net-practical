using System.ComponentModel.DataAnnotations;
namespace HotelBookingAPI.Models;

public class Booking
{
    public int Id { get; set; }

    [Required(ErrorMessage="Enetr the Customer Name")]
    public int CustomerId { get; set; }

    [Required(ErrorMessage ="Enter the Chekin Date and time")]
    public DateTime Checkin { get; set; }

    [Required(ErrorMessage ="Enter the Checkout Date and time")]
    public DateTime Checkout { get; set; }

    [Required(ErrorMessage ="Enter the Total Ammount ")]
    public decimal TotalAmt { get; set; }

    [Required(ErrorMessage ="Enter the Status of the Hostel")]
    public string Status { get; set; }=String.Empty;

    public Customer? Customer { get; set; }

    public ICollection<BookingRoom>? BookingRooms { get; set; }
}