using System.ComponentModel.DataAnnotations;

namespace HotelBookingSystemMVC.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; } 
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(30, ErrorMessage = "Name can't exceed 30 letters")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Your Email Address")]
        [EmailAddress(ErrorMessage = "Enter a valid Email Address")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Your Contact No.")]
        [Range(6000000000, 9999999999, ErrorMessage = "Phone number must be 10 digits")]
        public long Phone { get; set; }
    }
}
