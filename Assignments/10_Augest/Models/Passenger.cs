using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage ="Invalid Phone No.")]
        public string Phone { get; set; }= string.Empty;

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }=string.Empty;
    }
}