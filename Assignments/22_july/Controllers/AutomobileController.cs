using Microsoft.AspNetCore.Mvc;
using AutomobileSystem_MVC.Models;

namespace AutomobileSystem_MVC.Controllers
{
    public class AutomobileController : Controller
    {
        // Display the Automobile Registration Form
        public IActionResult Index()
        {
            return View();
        }

        // Receive Automobile Details
        [HttpPost]
        public IActionResult Index(Automobile automobile)
        {
            if (ModelState.IsValid)
            {
                TempData["VehicleName"] = automobile.VehicleName;
                TempData["Brand"] = automobile.Brand;

                return RedirectToAction("Index", "Manufacturer");
            }

            return View(automobile);
        }
    }
}