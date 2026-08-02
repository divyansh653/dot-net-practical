
using _30_july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _30_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBatches()
        {
            var batches = new List<Batch>
            {
                new Batch
                {
                    Id = 101,
                    BatchName = "Batch A",
                    CourseName = "C#"
                },
                new Batch
                {
                    Id = 102,
                    BatchName = "Batch B",
                    CourseName = "ASP.NET Core"
                },
                new Batch
                {
                    Id = 103,
                    BatchName = "Batch C",
                    CourseName = "Java"
                },
            

           

    new Batch
    {
        Id = 101,
        BatchName = "C# Batch",
        CourseId = 1
    },
    new Batch
    {
        Id = 102,
        BatchName = "ASP.NET Batch",
        CourseId = 2
    },
    new Batch
    {
        Id = 103,
        BatchName = "Java Batch",
        CourseId = 3
    },
    new Batch
    {
        Id = 104,
        BatchName = "Python Batch",
        CourseId = 4
    }
};

            return Ok(batches);
        }
    }
}