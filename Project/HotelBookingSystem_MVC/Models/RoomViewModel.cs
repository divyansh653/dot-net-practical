using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemMVC.Models
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        [Display(Name = "Room Number")]
        public int Room_Number { get; set; }

        [Required(ErrorMessage = "Enter the room type")]
        [Display(Name = "Room Type")]
        public string Room_Type { get; set; } = "Standard";

        [Required(ErrorMessage = "Enter the price")]
        [Range(0, 100000, ErrorMessage = "Enter a valid price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Enter the status")]
        public string Status { get; set; } = "Available";
    }
}
