using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services.Abstractions
{
	public interface IPizzaService
	{
		public IEnumerable<Pizza> GetMenu(int restaurantId);

		public Pizza GetPizza(int id);

		public Pizza GetPizza(int restaurantId, int id);

		public IEnumerable<Topping> GetToppings();
	}
}
