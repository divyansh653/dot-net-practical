using System.ComponentModel.DataAnnotations;

namespace July_21.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student name is mandatory")]
        [StringLength(20, MinimumLength = 3,
            ErrorMessage = "Name must be between 3 and 20 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student age is mandatory")]
        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Student mail id is mandatory")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student enrolled course is mandatory")]
        public string Course { get; set; } = string.Empty;
    }
}