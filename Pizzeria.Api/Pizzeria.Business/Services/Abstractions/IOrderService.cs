using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services.Abstractions
{
	public interface IOrderService
	{
		public Order Get(int id);

		public Order Create(int restaurantId, int pizzaId, int[]? toppingIds);

		public void DeleteOrder(int id);

		public void AddPizzaToOrder(int orderId, int pizzaId, int[]? toppingIds);

		public void RemovePizzaFromOrder(int pizzaOrderId);
	}
}
