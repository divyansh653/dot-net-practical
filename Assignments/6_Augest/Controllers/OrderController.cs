using _6_Augest.Models;
using _6_Augest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _6_Augest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService service;

        public OrdersController(IOrderService service)
        {
            this.service = service;
        }

        //fetch all order from order table
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(service.GetOrders());
        }

        //fetch order detail from order table based on OrderId
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            return Ok(service.GetOrderById(id));
        }

        //add new order record in order table
        [HttpPost]
        public IActionResult AddOrder(Order order)
        {
            service.AddOrder(order);
            return Ok("Order Added Successfully");
        }

        //modify order details from order table based on OrderId
        [HttpPut]
        public IActionResult UpdateOrder(Order order)
        {
            service.UpdateOrder(order);
            return Ok("Order Updated Successfully");
        }

        //remove order record from order table based on OrderId
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            service.DeleteOrder(id);
            return Ok("Order Deleted Successfully");
        }
    }
}