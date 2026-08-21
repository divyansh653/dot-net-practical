using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelBookingSystemMVC.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HotelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client =
                _httpClientFactory.CreateClient("HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var hotels =
                await client.GetFromJsonAsync<List<HotelViewModel>>(
                    "api/Hotel");

            return View(
                hotels ?? new List<HotelViewModel>());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            HotelViewModel hotel)
        {
            if (!ModelState.IsValid)
            {
                return View(hotel);
            }

            var client =
                _httpClientFactory.CreateClient("HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response =
                await client.PostAsJsonAsync(
                    "api/Hotel",
                    hotel);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var error =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError(
                "",
                $"Unable to add hotel. {error}");

            return View(hotel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var client =
                _httpClientFactory.CreateClient("HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var hotel =
                await client.GetFromJsonAsync<HotelViewModel>(
                    $"api/Hotel/{id}");

            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }
    }
}