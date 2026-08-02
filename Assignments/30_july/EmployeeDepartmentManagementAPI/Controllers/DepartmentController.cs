using EmployeeDepartmentManagementAPI.Data;
using EmployeeDepartmentManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDepartmentManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        // GET: api/Departments
        [HttpGet]
        public ActionResult<List<Department>> GetAllDepartments()
        {
            return Ok(InMemoryData.Departments);
        }

        // GET: api/Departments/1
        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound(
                    new
                    {
                        Message = "Department not found."
                    });
            }

            return Ok(department);
        }

        // POST: api/Departments
        [HttpPost]
        public ActionResult AddDepartment(
            Department department)
        {
            bool nameExists =
                InMemoryData.Departments.Any(
                    d => d.DepartmentName.Equals(
                        department.DepartmentName,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (nameExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Department name already exists."
                    });
            }

            bool codeExists =
                InMemoryData.Departments.Any(
                    d => d.DepartmentCode.Equals(
                        department.DepartmentCode,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (codeExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Department code already exists."
                    });
            }

            if (department.Status != "Active" &&
                department.Status != "Inactive")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Status must be Active or Inactive."
                    });
            }

            department.DepartmentId =
                InMemoryData.Departments.Count == 0
                ? 1
                : InMemoryData.Departments.Max(
                    d => d.DepartmentId) + 1;

            InMemoryData.Departments.Add(
                department);

            return CreatedAtAction(
                nameof(GetDepartmentById),
                new
                {
                    id = department.DepartmentId
                },
                department);
        }

        // PUT: api/Departments/1
        [HttpPut("{id}")]
        public ActionResult UpdateDepartment(
            int id,
            Department updatedDepartment)
        {
            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Department not found."
                    });
            }

            bool nameExists =
                InMemoryData.Departments.Any(
                    d =>
                    d.DepartmentId != id &&
                    d.DepartmentName.Equals(
                        updatedDepartment
                            .DepartmentName,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (nameExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Department name already exists."
                    });
            }

            bool codeExists =
                InMemoryData.Departments.Any(
                    d =>
                    d.DepartmentId != id &&
                    d.DepartmentCode.Equals(
                        updatedDepartment
                            .DepartmentCode,
                        StringComparison
                            .OrdinalIgnoreCase));

            if (codeExists)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Department code already exists."
                    });
            }

            if (updatedDepartment.Status !=
                    "Active" &&
                updatedDepartment.Status !=
                    "Inactive")
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Status must be Active or Inactive."
                    });
            }

            department.DepartmentName =
                updatedDepartment.DepartmentName;

            department.DepartmentCode =
                updatedDepartment.DepartmentCode;

            department.Status =
                updatedDepartment.Status;

            return Ok(
                new
                {
                    Message =
                    "Department updated successfully.",
                    Department = department
                });
        }

        // DELETE: api/Departments/1
        [HttpDelete("{id}")]
        public ActionResult DeleteDepartment(int id)
        {
            Department? department =
                InMemoryData.Departments
                .FirstOrDefault(
                    d => d.DepartmentId == id);

            if (department == null)
            {
                return NotFound(
                    new
                    {
                        Message =
                        "Department not found."
                    });
            }

            bool employeesAssigned =
                InMemoryData.Employees.Any(
                    e => e.DepartmentId == id);

            if (employeesAssigned)
            {
                return BadRequest(
                    new
                    {
                        Message =
                        "Department cannot be deleted " +
                        "because employees are assigned " +
                        "to it."
                    });
            }

            InMemoryData.Departments.Remove(
                department);

            return Ok(
                new
                {
                    Message =
                    "Department deleted successfully."
                });
        }
    }
}