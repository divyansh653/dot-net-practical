using HotelBookingSystemMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;

namespace HotelBookingSystemMVC.Controllers
{
    public class BillingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BillingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("HotelBookingSystem");

            var token = HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "Account");
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var bills = await client.GetFromJsonAsync<List<BillingViewModel>>(
                "api/Billing");

            return View(bills ?? new List<BillingViewModel>());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadReservations();

            return View(new BillingViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillingViewModel model)
        {
            if (model.ReservationId <= 0)
            {
                ModelState.AddModelError(
                    "ReservationId",
                    "Select a reservation.");
            }

            if (!ModelState.IsValid)
            {
                await LoadReservations();
                return View(model);
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
                    $"api/Billing/{model.ReservationId}",
                    new { });

            if (response.IsSuccessStatusCode)
            {
                var bill =
                    await response.Content
                        .ReadFromJsonAsync<BillingViewModel>();

                if (bill != null)
                {
                    return RedirectToAction(
                        nameof(Payment),
                        new { id = bill.Id });
                }

                return RedirectToAction(nameof(Index));
            }

            var error =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError("", error);

            await LoadReservations();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Payment(int id)
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

            var bill =
                await client.GetFromJsonAsync<BillingViewModel>(
                    $"api/Billing/{id}");

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(
            int id,
            BillingViewModel model)
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

            var response =
                await client.PutAsJsonAsync(
                    $"api/Billing/{id}",
                    new { });

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(
                    nameof(Payment),
                    new { id });
            }

            var error =
                await response.Content.ReadAsStringAsync();

            ModelState.AddModelError("", error);

            var bill =
                await client.GetFromJsonAsync<BillingViewModel>(
                    $"api/Billing/{id}");

            return View(bill ?? model);
        }

        private async Task LoadReservations()
        {
            var client =
                _httpClientFactory.CreateClient("HotelBookingSystem");

            var token =
                HttpContext.Session.GetString("JwtToken");

            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var reservations =
                await client.GetFromJsonAsync<
                    List<ReservationViewModel>>(
                        "api/Reservation")
                ?? new List<ReservationViewModel>();

            ViewBag.Reservations = new SelectList(
                reservations.Select(r => new
                {
                    r.Id,
                    Text =
                        $"Reservation #{r.Id} " +
                        $"(Customer {r.CustomerId})"
                }),
                "Id",
                "Text");
        }
    }
}