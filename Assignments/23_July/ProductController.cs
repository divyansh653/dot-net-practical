using Microsoft.AspNetCore.Mvc;
using _23_july.Models;

namespace _23_july.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Home");
            }

            List<Product> products = new List<Product>()
            {
                new Product { ID = 1, Name = "Laptop", Price = 78000 },
                new Product { ID = 2, Name = "Phone", Price = 80000 },
                new Product { ID = 3, Name = "Charger", Price = 700 },
                new Product { ID = 4, Name = "Earphone", Price = 8000 }
            };

            return View(products);
        }
    }
}