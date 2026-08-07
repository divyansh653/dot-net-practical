using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _25_july.Models;

namespace _25_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Divyansh",
                Age = 19,
                Department = "Computer Science"
            },
            new Student
            {
                Id = 2,
                Name = "Mayur",
                Age = 20,
                Department = "Information Technology"
            },
            new Student
            {
                Id = 3,
                Name = "Devang",
                Age = 20,
                Department = "Mechanical"
            },
            new Student
            {
                Id = 4,
                Name = "Ayush",
                Age = 21,
                Department = "Electronics"
            }
        };

        // GET: api/Student
        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students); //200
        }

        // GET: api/Student/1
        [HttpGet("{Id}")]
        public IActionResult GetStudent(int Id)
        {
            var student = students.FirstOrDefault(s => s.Id == Id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost] // Add new student in existing student list
        public IActionResult AddStudent(Student student)
        {
            students.Add(student);

            return CreatedAtAction(
                nameof(GetStudent),
                new { Id = student.Id },
                student
            );
        }

        // PUT: api/Student/1
        [HttpPut("{Id}")] // Edit or modify existing student data based on id
        public IActionResult UpdateStudent(int Id, Student updateStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == Id);

            if (student == null)
                return NotFound();

           
            student.Age = updateStudent.Age;
           

            return NoContent();
        }

        // DELETE: api/Student/1
        [HttpDelete("{Id}")]
        public IActionResult DeleteStudent(int Id)
        {
            var student = students.FirstOrDefault(s => s.Id == Id);

            if (student == null)
                return NotFound();   // 404

            students.Remove(student);

            return NoContent();      // 204
        }
    }
}