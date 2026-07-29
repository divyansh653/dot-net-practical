using Microsoft.AspNetCore.Mvc;
using _16Jul.Models;

namespace _16Jul.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Id = 101,
                    Name = "Divyansh",
                    Age = 20,
                    Course = "Dot Net Framework",
                    Gender = "Male",
                    Qualification = "12th",
                    Fees = 98666
                },
                new Student
                {
                    Id = 102,
                    Name = "Aditya",
                    Age = 19,
                    Course = "Java Framework",
                    Gender = "Male",
                    Qualification = "BE",
                    Fees = 24843
                },
                new Student
                {
                    Id = 103,
                    Name = "Kartik",
                    Age = 20,
                    Course = "Frontend Framework",
                    Gender = "Male",
                    Qualification = "B.Sc",
                    Fees = 50760
                },
                new Student
                {
                    Id = 104,
                    Name = "Saloni",
                    Age = 21,
                    Course = "Networking",
                    Gender = "Female",
                    Qualification = "BE",
                    Fees = 32000
                }
            };

            return View(students);
        }
    }
}