using _3_Aug.Models;
using _3_Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _3_Aug.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/Student
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult Post(Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.AddStudent(student);

            return Ok(student);
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Id mismatch");
            }

            var existingStudent = _service.GetStudent(id);

            if (existingStudent == null)
            {
                return NotFound("Student not found");
            }

            _service.UpdateStudent(student);

            return Ok("Student Updated");
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = _service.GetStudent(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            _service.DeleteStudent(id);

            return Ok("Student Deleted");
        }
    }
}