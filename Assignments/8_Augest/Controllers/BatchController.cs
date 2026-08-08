using Microsoft.AspNetCore.Mvc;
using _8_Augest.Models;
using _8_Augest.Repository;

namespace _8_Augest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchesController : ControllerBase
    {
        private readonly IBatchService repository;

        public BatchesController(IBatchService repository)
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
        public IActionResult Post(Batch batch)
        {
            repository.Add(batch);

            return Ok(batch);
        }

        [HttpPut("{id}")]
        public IActionResult Put(
            int id,
            Batch batch)
        {
            batch.BatchId = id;

            repository.Update(batch);

            return Ok(batch);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var batch = repository.GetById(id);

            repository.Delete(batch);

            return Ok();
        }
    }
}