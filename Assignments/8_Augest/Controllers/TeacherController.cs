using Microsoft.AspNetCore.Mvc;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService repository;

        public TeachersController(ITeacherService repository)
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
        public IActionResult Post(Teacher teacher)
        {
            repository.Add(teacher);

            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            Teacher teacher)
        {
            teacher.TeacherId = id;

            repository.Update(teacher);

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teacher = repository.GetById(id);

            repository.Delete(teacher);

            return Ok();
        }
    }
}