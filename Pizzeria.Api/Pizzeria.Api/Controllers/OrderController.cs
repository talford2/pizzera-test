using Microsoft.AspNetCore.Mvc;
using Pizzeria.Api.Models;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;

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
        public Order CreateOrder(NewOrder order)
        {
            return _orderService.Create(order.RestaurantId, order.PizzaId);
        }

        [HttpPost("order/pizza-order")]
        public Order AddPizzaToOrder(AddPizzaToOrder order)
        {
            _orderService.AddPizzaToOrder(order.OrderId, order.PizzaId);
            return _orderService.Get(order.OrderId);
        }

        [HttpDelete("order/pizza-order/{pizzaOrderId}")]
        public bool RemovePizzaFromOrder(int pizzaOrderId)
        {
            _orderService.RemovePizzaFromOrder(pizzaOrderId);
            return true;
        }
    }
}
