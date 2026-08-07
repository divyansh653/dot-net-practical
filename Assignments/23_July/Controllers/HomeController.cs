using Microsoft.AspNetCore.Mvc;

namespace _23_july.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Login()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username == "admin" && password == "12345")
            {
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Message = "Invalid Username or Password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}