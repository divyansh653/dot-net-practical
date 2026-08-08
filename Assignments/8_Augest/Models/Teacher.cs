using System.ComponentModel.DataAnnotations;

namespace _8_Augest.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required(ErrorMessage = " Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;

        [Range(1, 40)]
        public int Experience { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
