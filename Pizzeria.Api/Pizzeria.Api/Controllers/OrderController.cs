using Microsoft.AspNetCore.Mvc;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("order/{orderId}")]
        public Order GetOrder(int orderId)
        {
            return _orderService.Get(orderId);
        }

        [HttpPost("order")]
        public Order CreateOrder(int restaurantId, int pizzaId)
        {
            return _orderService.Create(restaurantId, pizzaId);
        }
    }
}
