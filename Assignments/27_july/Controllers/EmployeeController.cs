using _27_july.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace _27_july.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id = 101, Name = "Divyansh", LastName = "Mate", Dept = "CSE" , PhoneNum = 9175861354},
            new Employee(){Id = 102, Name = "Aditya", LastName = "Mishra", Dept = "IT" , PhoneNum = 9188862421},
            new Employee(){Id = 103, Name = "Devesh", LastName = "Talatule", Dept = "CSE" , PhoneNum = 9175358261},
            new Employee(){Id = 104, Name = "Devang", LastName = "Shinde", Dept = "Mech" , PhoneNum = 9145758621}


        };
        //get all employee list 
        [HttpGet]
        public IActionResult getEmployee()
        {
            return Ok(employees);//ok -200
        }


        //get wmployee by id 
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();

            }
            return Ok(employee);
        }

        //add new employee record
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        //edit employee record
        [HttpPut("{id}")]

        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            var employee1 = employees.FirstOrDefault(x => x.Id == id);
            if (employee1 == null)
            {
                return NotFound();
            }

            employee1.LastName = employee.LastName;
            return Ok(employee1);
        }
    }
}