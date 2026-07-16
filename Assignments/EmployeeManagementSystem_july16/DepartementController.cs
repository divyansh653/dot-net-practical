using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem_july16.Models;


namespace EmployeeManagementSystem_july16.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departments = new List<Department>()
            {
                new Department { DepartmentName = "IT",DepartmentHead = "Aditya",HeadContact = "9876543210",HeadEmail = "aditya30@gmail.com" },

                new Department { DepartmentName = "HR",DepartmentHead = "Saloni",HeadContact = "9876557484",HeadEmail = "saloni0601@gmail.com" },

                new Department { DepartmentName = "Finance",DepartmentHead = "Kartik",HeadContact = "9998887777",HeadEmail = "Kartik2006@gmail.com" }
            };

            return View(departments);
        }
    }
}