using Pizzeria.Repository.Models;

namespace Pizzeria.Repository.Interfaces
{
	public interface IPizzaToppingOrderRepository
	{
		public void AddPizzaToppingOrder(PizzaToppingOrderDto pizzaToppingOrder);

		public IEnumerable<PizzaToppingOrderDto> GetForPizzaOrder(int pizzaOrderId);
	}
}
