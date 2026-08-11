using System.ComponentModel.DataAnnotations;

namespace _10_Augest.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [StringLength(50)]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required")]
        [StringLength(10, MinimumLength = 10)]
        public string ContactNumber { get; set; } = string.Empty;
    }
}