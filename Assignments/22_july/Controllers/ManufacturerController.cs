using Microsoft.AspNetCore.Mvc;
using AutomobileSystem_MVC.Models;

namespace AutomobileSystem_MVC.Controllers
{
    public class ManufacturerController : Controller
    {
        // Display Manufacturer Form
        public IActionResult Index()
        {
            // Check whether Automobile registration was completed
            if (TempData["VehicleName"] == null || TempData["Brand"] == null)
            {
                return RedirectToAction("Index", "Automobile");
            }

            // Keep TempData values for the POST request
            TempData.Keep("VehicleName");
            TempData.Keep("Brand");

            return View();
        }

        // Receive Manufacturer Details
        [HttpPost]
        public IActionResult Index(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Success = "Automobile Registered Successfully";
                ViewBag.VehicleName = TempData["VehicleName"];
                ViewBag.Brand = TempData["Brand"];
                ViewBag.Manufacturer = manufacturer;

                return View("Index");
            }

            TempData.Keep("VehicleName");
            TempData.Keep("Brand");

            return View(manufacturer);
        }
    }
}