using _10_Augest.Models;
using _10_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Augest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService service;

        public PurchaseController(IPurchaseService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult CreatePurchase(Purchase purchase)
        {
            try
            {
                return Ok(service.CreatePurchase(purchase));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetPurchases()
        {
            return Ok(service.GetPurchases());
        }

        [HttpGet("{id}")]
        public IActionResult GetPurchaseById(int id)
        {
            var purchase = service.GetPurchaseById(id);

            if (purchase == null)
                return NotFound("Purchase not found");

            return Ok(purchase);
        }
    }
}