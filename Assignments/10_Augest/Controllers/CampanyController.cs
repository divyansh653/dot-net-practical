using _10_Augest.Models;
using _10_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Augest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreateCompany(Company company)
        {
            try
            {
                return Ok(service.CreateCompany(company));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            return Ok(service.GetCompanies());
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var company = service.GetCompanyById(id);

            if (company == null)
                return NotFound("Company not found");

            return Ok(company);
        }
    }
}