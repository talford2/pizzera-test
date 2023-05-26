using Pizzeria.Api.Models;
using Pizzeria.Api.Repositories;

namespace Pizzeria.Api.Services
{
    public interface IPizzaService
    {
        public IEnumerable<RestaurantPizzaPrice> GetPizzasForLocation(int restaurantId);
    }

    public class PizzaService : IPizzaService
    {
        private readonly IRestaurantPizzaPriceRepository _restaurantPizzaPriceRepository;

        public PizzaService(IRestaurantPizzaPriceRepository restaurantPizzaPriceRepository)
        {
            _restaurantPizzaPriceRepository = restaurantPizzaPriceRepository;
        }

        public IEnumerable<RestaurantPizzaPrice> GetPizzasForLocation(int restaurantId)
        {
            return _restaurantPizzaPriceRepository.GetMenu(restaurantId);
        }
    }
}
