using July_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace July_21.Controllers
{
    public class HomeController : Controller
    {
        // Display Registration Form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Handle Registration Form
        [HttpPost]
        public IActionResult Register(Student student)
        {
            // Check whether the model is valid or not
            if (ModelState.IsValid)
            {
                // Store student name to display on Schedule page
                TempData["StudentName"] = student.Name;

                // Redirect to Schedule page
                return RedirectToAction("Schedule");
            }

            // If validation fails, return to Register page
            return View(student);
        }

        // Display Course Schedule
        public IActionResult Schedule()
        {
            List<Course> course = new List<Course>()
            {
                new Course
                {
                    courseName = "ASP.NET",
                    sem = "Sem 3",
                    sessionTime = "9:30 AM - 12:00 PM",
                    days = "Mon - Tue"
                },

                new Course
                {
                    courseName = "C#",
                    sem = "Sem 3",
                    sessionTime = "9:30 AM - 11:00 AM",
                    days = "Mon - Fri"
                },

                new Course
                {
                    courseName = "MVC",
                    sem = "Sem 3",
                    sessionTime = "11:00 AM - 12:00 PM",
                    days = "Tue - Fri"
                }
            };

            return View(course);
        }
    }
}