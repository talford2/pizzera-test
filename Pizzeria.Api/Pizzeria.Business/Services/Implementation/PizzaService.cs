using Pizzeria.Business.Exceptions;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;
using Pizzeria.Repository.Interfaces;

namespace Pizzeria.Business.Services.Implementation
{
	public class PizzaService : IPizzaService
	{
		private readonly IRestaurantRepository _restaurantRepository;
		private readonly IRestaurantPizzaPriceRepository _restaurantPizzaPriceRepository;
		private readonly IPizzaRepository _pizzaRepository;
		private readonly IToppingRepository _toppingRepository;

		public PizzaService(IRestaurantRepository restaurantRepository, IRestaurantPizzaPriceRepository restaurantPizzaPriceRepository, IPizzaRepository pizzaRepository, IToppingRepository toppingRepository)
		{
			_restaurantRepository = restaurantRepository;
			_restaurantPizzaPriceRepository = restaurantPizzaPriceRepository;
			_pizzaRepository = pizzaRepository;
			_toppingRepository = toppingRepository;
		}

		public IEnumerable<Pizza> GetMenu(int restaurantId)
		{
			var restaurant = _restaurantRepository.Get(restaurantId);
			if (restaurant == null)
				throw new UnknownRestaurantException(restaurantId);

			var restaurantPizzas = _restaurantPizzaPriceRepository.GetForRestaurant(restaurantId);
			var pizzaDescriptions = _pizzaRepository.GetAll().ToDictionary(k => k.Id);

			var fullPizza = new List<Pizza>();
			foreach (var restaurantPizza in restaurantPizzas)
			{
				var pizzaDescription = pizzaDescriptions[restaurantPizza.PizzaId];
				fullPizza.Add(new Pizza
				{
					Id = restaurantPizza.PizzaId,
					RestaurantId = restaurantPizza.RestaurantId,
					BasePrice = restaurantPizza.Price,
					BaseIngredients = pizzaDescription.BaseIngredients,
					Name = pizzaDescription.Name
				});
			}

			return fullPizza;
		}

		public Pizza GetPizza(int restaurantId, int id)
		{
			var pizza = _pizzaRepository.Get(id);
			var pizzaPrice = _restaurantPizzaPriceRepository.GetPizza(restaurantId, id);

			return new Pizza
			{
				Id = pizzaPrice.PizzaId,
				Name = pizza.Name,
				BaseIngredients = pizza.BaseIngredients,
				BasePrice = pizzaPrice.Price,
				RestaurantId = pizzaPrice.RestaurantId
			};
		}

		public Pizza GetPizza(int id)
		{
			var pizza = _pizzaRepository.Get(id);
			return new Pizza
			{
				Id = pizza.Id,
				Name = pizza.Name,
				BaseIngredients = pizza.BaseIngredients
			};
		}

		public IEnumerable<Topping> GetToppings()
		{
			return _toppingRepository.GetAll().Select(t => new Topping
			{
				Id = t.Id,
				Name = t.Name,
				Price = t.Price,
			});
		}
	}
}
