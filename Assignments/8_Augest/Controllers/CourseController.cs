using Microsoft.AspNetCore.Mvc;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService repository;

        public CoursesController(ICourseService repository)
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
        public IActionResult Post(Course course)
        {
            repository.Add(course);

            return Ok(course);
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            Course course)
        {
            course.CourseId = id;

            repository.Update(course);

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var course = repository.GetById(id);

            repository.Delete(course);

            return Ok();
        }
    }
}