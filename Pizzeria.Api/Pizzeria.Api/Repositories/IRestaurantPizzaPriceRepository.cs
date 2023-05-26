using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IRestaurantPizzaPriceRepository
    {
        public RestaurantPizzaPrice GetPizza(int restaurantId, int pizzaId);

        public IEnumerable<RestaurantPizzaPrice> GetMenu(int restaurantId);
    }
}
