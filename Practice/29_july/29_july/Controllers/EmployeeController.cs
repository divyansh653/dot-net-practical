using _29_july.Models;
using _29_july.Services;
using Microsoft.AspNetCore.Mvc;

namespace _29_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            return Ok(_employeeService.getEmployees());
        }

        // GET: api/Employee/1
        [HttpGet("{deptid}")]
        public ActionResult<Employee> GetEmployee(int deptid)
        {
            var employee = _employeeService.getEmployee(deptid);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // GET: api/Employee/name/Divyansh
        [HttpGet("name/{Name}")]
        public ActionResult<Employee> GetEmployeeName(string Name)
        {
            var employee = _employeeService.getEmployeeName(Name);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            var result = _employeeService.addEmployee(employee);

            return Ok(result);
        }
    }
}