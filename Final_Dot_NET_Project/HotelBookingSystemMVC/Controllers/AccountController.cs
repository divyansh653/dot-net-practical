using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelBookingSystemMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var client =
                _httpClientFactory.CreateClient("HotelBookingSystem");

            var response =
                await client.PostAsJsonAsync("api/Auth/login", model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(
                    "",
                    "Invalid username or password.");

                return View(model);
            }

            var result =
                await response.Content.ReadFromJsonAsync<LoginResponse>();

            if (result == null || string.IsNullOrEmpty(result.Token))
            {
                ModelState.AddModelError(
                    "",
                    "Invalid username or password.");

                return View(model);
            }

            HttpContext.Session.SetString("JwtToken", result.Token);
            HttpContext.Session.SetString("Role", result.Role ?? string.Empty);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.UserName),
                new Claim(ClaimTypes.Role, result.Role ?? string.Empty)
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();

            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }
    }
}
