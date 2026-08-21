using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelBookingSystemMVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(
            IHttpClientFactory httpClientFactory)
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

            var reservations =
                await client.GetFromJsonAsync<
                    List<ReservationViewModel>>(
                    "api/Reservation");

            return View(
                reservations ??
                new List<ReservationViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCreateLists();

            var model = new ReservationViewModel
            {
                Check_In_Date = DateTime.Today,
                Check_Out_Date = DateTime.Today.AddDays(1),
                Status = "Booked",
                No_Guest = 1
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            ReservationViewModel model)
        {
            if (model.SelectedRoomIds == null ||
                model.SelectedRoomIds.Count == 0)
            {
                ModelState.AddModelError(
                    "",
                    "Please select at least one room.");
            }

            if (!ModelState.IsValid)
            {
                await LoadCreateLists();
                return View(model);
            }

            // CustomerId is NOT taken from the form.
            // API will get CustomerId from the JWT.

            var payload = new ReservationViewModel
            {
                Check_In_Date = model.Check_In_Date,

                Check_Out_Date = model.Check_Out_Date,

                Status = string.IsNullOrWhiteSpace(model.Status)
                    ? "Booked"
                    : model.Status,

                No_Guest = model.No_Guest,

                ReservationRooms =
                    (model.SelectedRoomIds ??
                    new List<int>())
                    .Select(roomId =>
                        new ReservationRoomViewModel
                        {
                            RoomId = roomId
                        })
                    .ToList()
            };

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
                await client.PostAsJsonAsync(
                    "api/Reservation",
                    payload);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var error =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError("", error);

            await LoadCreateLists();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
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

            var reservation =
                await client.GetFromJsonAsync<
                    ReservationViewModel>(
                    $"api/Reservation/{id}");

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
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

            var reservation =
                await client.GetFromJsonAsync<
                    ReservationViewModel>(
                    $"api/Reservation/{id}");

            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(
            int id)
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

            var response =
                await client.DeleteAsync(
                    $"api/Reservation/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            var error =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError("", error);

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCreateLists()
        {
            var client =
                _httpClientFactory.CreateClient(
                    "HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            // Only load rooms.
            // Do NOT call api/Customer here.
            var rooms =
                await client.GetFromJsonAsync<
                    List<RoomViewModel>>(
                    "api/Room")
                ?? new List<RoomViewModel>();

            ViewBag.Rooms = rooms;
        }
    }
}