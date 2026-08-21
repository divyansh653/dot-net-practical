using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemMVC.Models
{
    public class HotelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Hotel name")]
        [StringLength(30, ErrorMessage = "Hotel name can't exceed 30 letters")]
        [Display(Name = "Hotel Name")]
        public string HotelName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the City")]
        [StringLength(30, ErrorMessage = "City name can't exceed 30 letters")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the number of rooms")]
        [Range(1, 200, ErrorMessage = "Number of rooms must be between 1 and 200")]
        [Display(Name = "Number of Rooms")]
        public int Room { get; set; }
    }
}
