using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            Department department = new Department()
            {
                DepartmentName = "Computer Science",
                DepartmentHead = "Dr. Rajesh Sharma",
                HeadContactNumber = "9876543210",
                HeadEmail = "hod.cse@ssgmce.ac.in"
            };

            return View(department);
        }
    }
}