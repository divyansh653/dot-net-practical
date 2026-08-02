
using _30_july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _30_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCourses()
        {
            var courses = new List<Course>
            {
                new Course
                {
                    Id = 1,
                    CourseName = "C#",
                    Duration = "3 Months",
                    Fees = 25000
                },
                new Course
                {
                    Id = 2,
                    CourseName = "ASP.NET Core",
                    Duration = "4 Months",
                    Fees = 30000
                },
                new Course
                {
                    Id = 3,
                    CourseName = "Java",
                    Duration = "5 Months",
                    Fees = 35000
                },
                new Course
                {
                    Id = 4,
                    CourseName = "Python",
                    Duration = "3 Months",
                    Fees = 20000
                }
            };

            return Ok(courses);
        }
    }
}