using _24_july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _24_july.Controllers
{
    public class HomeController : Controller
    {
        // GET : Login
        public IActionResult Index()
        {
            return View();
        }

        // POST : Login
        [HttpPost]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.Username == "admin" && student.Password == "123456")
                {
                    HttpContext.Session.SetString("User", student.Username);
                    return RedirectToAction("Dashboard");
                }

                ViewBag.Error = "Invalid username or password";
            }

            return View(student);
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Index");
            }

            List<Stationery> stationeryList = new List<Stationery>()
    {
        new Stationery
        {
            ItemName = "Notebook",
            Brand = "Classmate",
            Price = 80,
            Quantity = 20,
            Color = "Blue"
        },

        new Stationery
        {
            ItemName = "Pen",
            Brand = "Cello",
            Price = 15,
            Quantity = 100,
            Color = "Black"
        },

        new Stationery
        {
            ItemName = "Pencil",
            Brand = "Apsara",
            Price = 10,
            Quantity = 150,
            Color = "Yellow"
        },

        new Stationery
        {
            ItemName = "Eraser",
            Brand = "Natraj",
            Price = 5,
            Quantity = 80,
            Color = "White"
        },

        new Stationery
        {
            ItemName = "Scale",
            Brand = "Camlin",
            Price = 20,
            Quantity = 50,
            Color = "Transparent"
        }
    };

            return View(stationeryList);
        }

           

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}