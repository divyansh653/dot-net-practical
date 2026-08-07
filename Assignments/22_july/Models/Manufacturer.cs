using System.ComponentModel.DataAnnotations;

namespace AutomobileSystem_MVC.Models
{
    public class Manufacturer
    {
        [Required(ErrorMessage = "Manufacturer Name is required")]
        public string ManufacturerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact Number is required")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter a valid 10-digit contact number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailAddress { get; set; } = string.Empty;
    }
}