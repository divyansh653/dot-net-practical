using System.ComponentModel.DataAnnotations;

namespace _30_july.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course Duration is required")]
        public string Duration { get; set; }

        [Range(1, 100000, ErrorMessage = "Fees must be valid")]
        public decimal Fees { get; set; }
    }
}