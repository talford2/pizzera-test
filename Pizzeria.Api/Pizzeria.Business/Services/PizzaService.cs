using Pizzeria.Business.Models;
using Pizzeria.Repository;

namespace Pizzeria.Business.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IRestaurantPizzaPriceRepository _restaurantPizzaPriceRepository;
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IRestaurantPizzaPriceRepository restaurantPizzaPriceRepository, IPizzaRepository pizzaRepository)
        {
            _restaurantPizzaPriceRepository = restaurantPizzaPriceRepository;
            _pizzaRepository = pizzaRepository;
        }

        public IEnumerable<Pizza> GetMenu(int restaurantId)
        {
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
    }
}
