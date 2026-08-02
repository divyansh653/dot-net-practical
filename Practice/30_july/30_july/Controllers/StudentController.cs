using _29_july.Models;
using _29_july.Services;
using _30_july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _29_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Student
        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(_studentService.getStudents());
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _studentService.getStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        

        // POST: api/Student
        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _studentService.addStudent(student);

            return Ok(result);
        }

        [HttpGet("details/{batchId}")]
        public IActionResult GetBatchDetails(int batchId)
        {
            var courses = new List<Course>
    {
        new Course
        {
            Id = 1,
            CourseName = "C# Full Stack",
            Duration = "6 Months",
            Fees = 50000
        },
        new Course
        {
            Id = 2,
            CourseName = "Java Full Stack",
            Duration = "6 Months",
            Fees = 55000
        },
        new Course
        {
            Id = 3,
            CourseName = "Python Development",
            Duration = "4 Months",
            Fees = 40000
        }
    };

            var batches = new List<Batch>
    {
        new Batch
        {
            Id = 101,
            BatchName = "C# Morning Batch",
            CourseId = 1
        },
        new Batch
        {
            Id = 102,
            BatchName = "Java Evening Batch",
            CourseId = 2
        },
        new Batch
        {
            Id = 103,
            BatchName = "Python Morning Batch",
            CourseId = 3
        }
    };

            var students = new List<Student>
    {
        new Student
            {
                Id = 1,
                FirstName = "Divyansh",
                LastName = "Mate",
                Phone = "9876543210",
                BatchId = 101
            },
            new Student
            {
                Id = 2,
                FirstName = "Aditya",
                LastName = "Mishra",
                Phone = "7886543211",
                BatchId = 102
            },
            new Student
            {
                Id = 3,
                FirstName = "Ayush",
                LastName = "Gokhale",
                Phone = "8576543212",
                BatchId = 103
            },
            new Student
            {
                Id = 4,
                FirstName = "Mayur",
                LastName = "Palve",
                Phone = "9576543213",
                BatchId = 104
            }
        };

            var batch = batches.FirstOrDefault(
                b => b.Id == batchId
            );

            if (batch == null)
            {
                return NotFound("Batch not found");
            }

            var course = courses.FirstOrDefault(
                c => c.Id == batch.CourseId
            );

            var enrolledStudents = students
                .Where(s => s.BatchId == batchId)
                .Select(s => new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    s.Phone
                })
                .ToList();

            var result = new
            {
                BatchId = batch.Id,
                BatchName = batch.BatchName,

                Course = new
                {
                    CourseId = course.Id,
                    CourseName = course.CourseName,
                    Duration = course.Duration,
                    Fees = course.Fees
                },

                EnrolledStudents = enrolledStudents
            };

            return Ok(result);
        }
    }
}