using Pizzeria.Repository.Interfaces;
using Pizzeria.Repository.Models;

namespace Pizzeria.Repository.Implementations
{
	public class PizzaToppingOrderRepository : IPizzaToppingOrderRepository
	{
		private static List<PizzaToppingOrderDto> _pizzaToppingOrder = new List<PizzaToppingOrderDto>() { };

		public void AddPizzaToppingOrder(PizzaToppingOrderDto topping)
		{
			_pizzaToppingOrder.Add(topping);
		}

		public IEnumerable<PizzaToppingOrderDto> GetForPizzaOrder(int pizzaOrderId)
		{
			return _pizzaToppingOrder.Where(t => t.PizzaOrderId == pizzaOrderId);
		}
	}
}
