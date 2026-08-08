using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace _8_Augest.Models
{
    public class Student
    {
        
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Student First Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Student First Name can not exceed 50 letters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Student Last Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Student Last Name can not exceed 50 letters")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email id  is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone No. is required")]
        [Phone]
        public double Phone { get; set; }

        [Required(ErrorMessage = "Student Date of Birth is required")]
        
        public string DateOfBirth { get; set; } = string.Empty;

        [Required(ErrorMessage = "BatchId is required")]
        [Range(1, 10)]
        public int BatchId { get; set; }

        public Batch? Batch { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }


    }
}
