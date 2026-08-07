using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        // Display Employee Registration Form
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Receive Employee Data
        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                TempData["EmployeeName"] = employee.EmployeeName;
                TempData["Department"] = employee.Department;

                return RedirectToAction("Success");
            }

            return View(employee);
        }

        // Success Page
        public IActionResult Success()
        {
            return View();
        }
    }
}