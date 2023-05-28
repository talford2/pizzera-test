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
			return _orderService.Create(order.RestaurantId, order.PizzaId, order.ToppingIds);
		}

		[HttpDelete("order/{orderId}")]
		public void DeleteOrder(int orderId)
		{
			_orderService.DeleteOrder(orderId);
		}

		[HttpPost("order/pizza-order")]
		public void AddPizzaToOrder(AddPizzaToOrder order)
		{
			_orderService.AddPizzaToOrder(order.OrderId, order.PizzaId, order.ToppingIds);
		}

		[HttpDelete("order/pizza-order/{pizzaOrderId}")]
		public void RemovePizzaFromOrder(int pizzaOrderId)
		{
			_orderService.RemovePizzaFromOrder(pizzaOrderId);
		}
	}
}
