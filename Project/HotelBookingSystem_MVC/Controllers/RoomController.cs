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
            var client =
                _httpClientFactory.CreateClient(
                    "HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            List<RoomViewModel>? rooms;

            if (hotelId.HasValue)
            {
                rooms =
                    await client.GetFromJsonAsync<
                        List<RoomViewModel>>(
                        $"api/Room/Hotel/{hotelId.Value}");

                ViewBag.HotelId = hotelId.Value;
            }
            else
            {
                rooms =
                    await client.GetFromJsonAsync<
                        List<RoomViewModel>>(
                        "api/Room");
            }

            return View(
                rooms ?? new List<RoomViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client =
                _httpClientFactory.CreateClient(
                    "HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var room =
                await client.GetFromJsonAsync<RoomViewModel>(
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

            var client =
                _httpClientFactory.CreateClient(
                    "HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var response =
                await client.PutAsJsonAsync(
                    $"api/Room/{id}",
                    room);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    nameof(Index),
                    new { hotelId = room.HotelId });
            }

            var errorMessage =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError(
                "",
                $"Unable to update room. {errorMessage}");

            return View(room);
        }
    }
}