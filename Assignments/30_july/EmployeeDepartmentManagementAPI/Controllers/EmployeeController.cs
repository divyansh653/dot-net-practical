using EmployeeDepartmentManagementAPI.Data;
using EmployeeDepartmentManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET: api/Employees
        [HttpGet]
        public ActionResult GetAllEmployees()
        {
            var employees =
                InMemoryData.Employees.Select(
                    employee => new
                    {
                        employee.EmployeeId,
                        employee.FirstName,
                        employee.LastName,
                        employee.Email,
                        employee.MobileNumber,
                        employee.DateOfBirth,
                        employee.Gender,
                        employee.Salary,
                        employee.DateOfJoining,
                        employee.DepartmentId,

                        DepartmentName =
                            InMemoryData.Departments
                            .FirstOrDefault(
                                department =>
                                department.DepartmentId ==
                                employee.DepartmentId)
                            ?.DepartmentName,

                        employee.Designation,
                        employee.EmploymentStatus
                    });

            return Ok(employees);
        }

        // GET: api/Employees/1
        [HttpGet("{id}")]
        public ActionResult GetEmployeeById(int id)
        {
            Employee? employee =
                InMemoryData.Employees
                .FirstOrDefault(
                    e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Employee not found."
                    });
            }

            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId ==
                         employee.DepartmentId);

            return Ok(
                new
                {
                    employee.EmployeeId,
                    employee.FirstName,
                    employee.LastName,
                    employee.Email,
                    employee.MobileNumber,
                    employee.DateOfBirth,
                    employee.Gender,
                    employee.Salary,
                    employee.DateOfJoining,
                    employee.DepartmentId,

                    DepartmentName =
                        department?.DepartmentName,

                    employee.Designation,
                    employee.EmploymentStatus
                });
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult AddEmployee(
            Employee employee)
        {
            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId ==
                         employee.DepartmentId);

            if (department == null)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Selected department does not exist."
                    });
            }

            if (department.Status != "Active")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employees cannot be assigned " +
                        "to an inactive department."
                    });
            }

            bool emailExists =
                InMemoryData.Employees.Any(
                    e => e.Email.Equals(
                        employee.Email,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (emailExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employee email already exists."
                    });
            }

            if (employee.EmploymentStatus !=
                    "Active" &&
                employee.EmploymentStatus !=
                    "Inactive")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employment status must be " +
                        "Active or Inactive."
                    });
            }

            employee.EmployeeId =
                InMemoryData.Employees.Count == 0
                ? 1
                : InMemoryData.Employees.Max(
                    e => e.EmployeeId) + 1;

            InMemoryData.Employees.Add(
                employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new
                {
                    id = employee.EmployeeId
                },
                employee);
        }

        // PUT: api/Employees/1
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(
            int id,
            Employee updatedEmployee)
        {
            Employee? employee =
                InMemoryData.Employees
                .FirstOrDefault(
                    e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Employee not found."
                    });
            }

            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId ==
                         updatedEmployee.DepartmentId);

            if (department == null)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Selected department does not exist."
                    });
            }

            if (department.Status != "Active")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employees cannot be assigned " +
                        "to an inactive department."
                    });
            }

            bool emailExists =
                InMemoryData.Employees.Any(
                    e =>
                    e.EmployeeId != id &&
                    e.Email.Equals(
                        updatedEmployee.Email,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (emailExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employee email already exists."
                    });
            }

            if (updatedEmployee
                    .EmploymentStatus !=
                    "Active" &&
                updatedEmployee
                    .EmploymentStatus !=
                    "Inactive")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Employment status must be " +
                        "Active or Inactive."
                    });
            }

            employee.FirstName =
                updatedEmployee.FirstName;

            employee.LastName =
                updatedEmployee.LastName;

            employee.Email =
                updatedEmployee.Email;

            employee.MobileNumber =
                updatedEmployee.MobileNumber;

            employee.DateOfBirth =
                updatedEmployee.DateOfBirth;

            employee.Gender =
                updatedEmployee.Gender;

            employee.Salary =
                updatedEmployee.Salary;

            employee.DateOfJoining =
                updatedEmployee.DateOfJoining;

            employee.DepartmentId =
                updatedEmployee.DepartmentId;

            employee.Designation =
                updatedEmployee.Designation;

            employee.EmploymentStatus =
                updatedEmployee
                .EmploymentStatus;

            return Ok(
                new
                {
                    Message =
                    "Employee updated successfully.",
                    Employee = employee
                });
        }

        // DELETE: api/Employees/1
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            Employee? employee =
                InMemoryData.Employees
                .FirstOrDefault(
                    e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Employee not found."
                    });
            }

            InMemoryData.Employees.Remove(
                employee);

            return Ok(
                new
                {
                    Message =
                    "Employee deleted successfully."
                });
        }

        // GET: api/Employees/search
        [HttpGet("search")]
        public ActionResult SearchEmployees(
            string? name,
            string? email,
            int? employeeId,
            string? status,
            int? departmentId)
        {
            var result =
                InMemoryData.Employees
                .AsEnumerable();

            if (!string.IsNullOrWhiteSpace(
                name))
            {
                result = result.Where(
                    e =>
                    e.FirstName.Contains(
                        name,
                        StringComparison
                            .OrdinalIgnoreCase)
                    ||
                    e.LastName.Contains(
                        name,
                        StringComparison
                            .OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(
                email))
            {
                result = result.Where(
                    e => e.Email.Contains(
                        email,
                        StringComparison
                            .OrdinalIgnoreCase));
            }

            if (employeeId.HasValue)
            {
                result = result.Where(
                    e => e.EmployeeId ==
                         employeeId.Value);
            }

            if (!string.IsNullOrWhiteSpace(
                status))
            {
                result = result.Where(
                    e => e.EmploymentStatus
                    .Equals(
                        status,
                        StringComparison
                            .OrdinalIgnoreCase));
            }

            if (departmentId.HasValue)
            {
                result = result.Where(
                    e => e.DepartmentId ==
                         departmentId.Value);
            }

            return Ok(result);
        }

        // GET: api/Employees/department/2
        [HttpGet("department/{departmentId}")]
        public ActionResult
            GetEmployeesByDepartment(
                int departmentId)
        {
            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId ==
                         departmentId);

            if (department == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Department not found."
                    });
            }

            var employees =
                InMemoryData.Employees
                .Where(
                    e => e.DepartmentId ==
                         departmentId)
                .ToList();

            return Ok(
                new
                {
                    Department =
                        department.DepartmentName,

                    Employees = employees
                });
        }
    }
}