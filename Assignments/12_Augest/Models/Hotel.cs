using HotelBookingAPI.Models;
using System.ComponentModel.DataAnnotations;

public class Hotel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Enter The name ")]
    [StringLength(20, ErrorMessage = "Name can't excced above 20 letters")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage ="Enter the city")]
    [StringLength(20,ErrorMessage ="City can't be exceed above 20 letters")]
    public string City { get; set; }= string.Empty;

    public ICollection<Room>? Rooms { get; set; }
}