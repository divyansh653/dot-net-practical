using Microsoft.AspNetCore.Mvc;
using EmployeeManagementSystem_july16.Models;


namespace EmployeeManagementSystem_july16.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee { EmployeeId = 101,Name = "Divyansh",Department = "IT",Salary = 50000,Email = "divyansh2@gmail.com" },


                new Employee { EmployeeId = 102,Name = "Snehal",Department = "HR",Salary = 45000,Email = "snehal2006@gmail.com" },

                new Employee { EmployeeId = 103,Name = "Devesh",Department = "Finance",Salary = 60000,Email = "devesh0611@gmail.com" }
            };

            return View(employees);
        }
    }
}