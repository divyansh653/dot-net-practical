using System.ComponentModel.DataAnnotations;

namespace _4_Augest.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is required")]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(30)]
        public string StudentName { get; set; }
    }
}