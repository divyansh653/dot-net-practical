using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelBookingSystemMVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int? hotelId)
        {
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            List<RoomViewModel>? rooms;

            if (hotelId.HasValue && hotelId.Value > 0)
            {
                rooms = await client.GetFromJsonAsync<List<RoomViewModel>>(
                    $"api/Room/Hotel/{hotelId.Value}");

                ViewBag.HotelId = hotelId.Value;
            }
            else
            {
                rooms = await client.GetFromJsonAsync<List<RoomViewModel>>(
                    "api/Room");
            }

            ViewBag.Hotels = await client.GetFromJsonAsync<List<HotelViewModel>>(
                "api/Hotel") ?? new List<HotelViewModel>();

            ViewBag.IsAdmin = HttpContext.Session.GetString("Role") == "Admin";

            return View(rooms ?? new List<RoomViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomViewModel room)
        {
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (room.HotelId <= 0)
            {
                TempData["Error"] = "Please select a hotel.";
                return RedirectToAction(nameof(Index));
            }

            if (room.Id <= 0)
            {
                TempData["Error"] = "Room ID is required.";
                return RedirectToAction(nameof(Index), new { hotelId = room.HotelId });
            }

            var response = await client.PostAsJsonAsync("api/Room", room);

            if (!response.IsSuccessStatusCode)
            {
                TempData["Error"] = await response.Content.ReadAsStringAsync();
                return RedirectToAction(nameof(Index), new { hotelId = room.HotelId });
            }

            return RedirectToAction(nameof(Index), new { hotelId = room.HotelId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var room = await client.GetFromJsonAsync<RoomViewModel>(
                $"api/Room/{id}");

            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            RoomViewModel room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(room);
            }

            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var response = await client.PutAsJsonAsync(
                $"api/Room/{id}",
                room);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    nameof(Index),
                    new { hotelId = room.HotelId });
            }

            var errorMessage = await response.Content.ReadAsStringAsync();

            ModelState.AddModelError(
                "",
                $"Unable to update room. {errorMessage}");

            return View(room);
        }

        private HttpClient? CreateClient()
        {
            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient("HotelBookingSystem");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            return client;
        }
    }
}
