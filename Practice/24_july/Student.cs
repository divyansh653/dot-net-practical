using System.ComponentModel.DataAnnotations;

namespace _24_july.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = String.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = String.Empty;
    }
}