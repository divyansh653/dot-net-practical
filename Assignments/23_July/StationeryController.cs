using Microsoft.AspNetCore.Mvc;
using _23_july.Models;

namespace _23_july.Controllers
{
    public class StationeryController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            List<Stationery> stationery = new List<Stationery>()
            {
                new Stationery { ID = 1, Name = "Pen", Price = 20 },
                new Stationery { ID = 2, Name = "Pencil", Price = 10 },
                new Stationery { ID = 3, Name = "Notebook", Price = 80 },
                new Stationery { ID = 4, Name = "Eraser", Price = 5 },
                new Stationery { ID = 5, Name = "Scale", Price = 15 }
            };

            return View(stationery);
        }
    }
}