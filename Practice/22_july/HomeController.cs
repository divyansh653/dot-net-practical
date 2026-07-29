using _22_july.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22_july.Controllers
{
    public class HomeController : Controller
    {
        // Display Form
        public IActionResult Index()
        {
            return View();
        }

        // Receive Form Data
        [HttpPost]
        public IActionResult Index(Stationery stationery)
        {
            if (ModelState.IsValid)
            {
                return Content(
                    $"Product Name : {stationery.Name}, " +
                    $"Price : {stationery.Price}, " +
                    $"Category : {stationery.Category}, " +
                    $"Stock : {stationery.Stock}, " +
                    $"Item Name : {stationery.ItemName}, " +
                    $"Brand : {stationery.Brand}, " +
                    $"Quantity : {stationery.Quantity}"
                );
            }

            return View(stationery);
        }
    }
}