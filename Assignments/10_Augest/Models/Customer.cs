using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
    }
}