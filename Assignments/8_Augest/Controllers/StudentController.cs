using Microsoft.AspNetCore.Mvc;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService repository;

        public StudentsController(IStudentService repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post(Student student)
        {
            repository.Add(student);

            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            student.StudentId = id;

            repository.Update(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = repository.GetById(id);

            repository.Delete(student);

            return Ok();
        }
    }
}