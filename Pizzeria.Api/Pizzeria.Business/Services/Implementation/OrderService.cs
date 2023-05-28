using Pizzeria.Business.Exceptions;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;
using Pizzeria.Repository.Interfaces;
using Pizzeria.Repository.Models;

namespace Pizzeria.Business.Services.Implementation
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IPizzaOrderRepository _pizzaOrderRepository;
		private readonly IPizzaToppingOrderRepository _pizzaToppingOrderRepository;

		private readonly IRestaurantService _restaurantService;
		private readonly IPizzaService _pizzaService;

		public OrderService(IOrderRepository orderRepository, IPizzaOrderRepository pizzaOrderRepository, IPizzaToppingOrderRepository pizzaToppingOrderRepository, IRestaurantService restaurantService, IPizzaService pizzaService)
		{
			_orderRepository = orderRepository;
			_pizzaOrderRepository = pizzaOrderRepository;
			_pizzaToppingOrderRepository = pizzaToppingOrderRepository;
			_restaurantService = restaurantService;
			_pizzaService = pizzaService;
		}

		public Order Get(int id)
		{
			var order = _orderRepository.Get(id);
			if (order == null)
				throw new UnknownOrderException(id);

			var restaurant = _restaurantService.Get(order.RestaurantId);
			var pizzaOrders = _pizzaOrderRepository.GetForOrder(order.Id);

			var allToppings = _pizzaService.GetToppings();

			return new Order
			{
				Id = id,
				Restaurant = restaurant,
				PizzaOrders = pizzaOrders.Select(o =>
				{
					var dtoToppings = _pizzaToppingOrderRepository.GetForPizzaOrder(o.Id);
					var toppings = allToppings.Where(t => dtoToppings.Any(i => i.ToppingId == t.Id));

					return new PizzaOrder
					{
						Id = o.Id,
						Pizza = _pizzaService.GetPizza(restaurant.Id, o.PizzaId),
						ExtraToppings = toppings
					};
				})
			};
		}

		// Order always starts with 1 pizza
		public Order Create(int restaurantId, int pizzaId, int[]? toppingIds)
		{
			var newOrderId = _orderRepository.Create(new OrderDto { RestaurantId = restaurantId });
			var restaurant = _restaurantService.Get(restaurantId);
			var pizzaOrderId = _pizzaOrderRepository.Create(newOrderId, pizzaId);

			foreach (var toppingId in toppingIds)
			{
				_pizzaToppingOrderRepository.AddPizzaToppingOrder(new PizzaToppingOrderDto { PizzaOrderId = pizzaOrderId, ToppingId = toppingId });
			}

			return Get(newOrderId);
		}

		public void AddPizzaToOrder(int orderId, int pizzaId, int[]? toppingIds)
		{
			var pizzaOrderId = _pizzaOrderRepository.Create(orderId, pizzaId);

			foreach (int toppingId in toppingIds)
				_pizzaToppingOrderRepository.AddPizzaToppingOrder(new PizzaToppingOrderDto { PizzaOrderId = pizzaOrderId, ToppingId = toppingId });
		}

		public void RemovePizzaFromOrder(int pizzaOrderId)
		{
			_pizzaOrderRepository.Delete(pizzaOrderId);
		}
	}
}
