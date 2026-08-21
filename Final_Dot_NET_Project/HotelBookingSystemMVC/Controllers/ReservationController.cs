using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var reservations =
                await client.GetFromJsonAsync<List<ReservationViewModel>>(
                    "api/Reservation");

            return View(
                reservations ??
                new List<ReservationViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadCreateLists(0);

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
            if (model.HotelId <= 0)
            {
                ModelState.AddModelError("", "Please select a hotel.");
            }

            if (model.SelectedRoomIds == null ||
                model.SelectedRoomIds.Count == 0)
            {
                ModelState.AddModelError(
                    "",
                    "Please select at least one room.");
            }

            if (!ModelState.IsValid)
            {
                await LoadCreateLists(model.HotelId);
                return View(model);
            }

            var payload = new ReservationViewModel
            {
                CustomerId = model.CustomerId,

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

            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

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

            await LoadCreateLists(model.HotelId);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var reservation =
                await client.GetFromJsonAsync<ReservationViewModel>(
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
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var reservation =
                await client.GetFromJsonAsync<ReservationViewModel>(
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
            var client = CreateClient();

            if (client == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var response =
                await client.DeleteAsync(
                    $"api/Reservation/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task LoadCreateLists(int hotelId)
        {
            var client = CreateClient();

            if (client == null)
            {
                ViewBag.Customers = new SelectList(new List<CustomerViewModel>(), "Id", "Name");
                ViewBag.Hotels = new List<HotelViewModel>();
                ViewBag.Rooms = new List<RoomViewModel>();
                return;
            }

            var customers =
                await client.GetFromJsonAsync<List<CustomerViewModel>>(
                    "api/Customer")
                ?? new List<CustomerViewModel>();

            ViewBag.Customers = new SelectList(customers, "Id", "Name");

            ViewBag.Hotels =
                await client.GetFromJsonAsync<List<HotelViewModel>>(
                    "api/Hotel")
                ?? new List<HotelViewModel>();

            ViewBag.Rooms =
                await client.GetFromJsonAsync<List<RoomViewModel>>(
                    "api/Room")
                ?? new List<RoomViewModel>();
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
