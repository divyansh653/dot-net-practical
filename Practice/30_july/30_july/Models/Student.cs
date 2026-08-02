using System.ComponentModel.DataAnnotations;

namespace _29_july.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "First Name must contain at least 3 letters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Last Name must contain at least 3 letters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "Phone Number must contain exactly 10 digits")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "BatchId is required")]
        public int BatchId { get; set; }
    }
}