using Pizzeria.Repositories.Models;

namespace Pizzeria.Repository.Interfaces
{
    public interface IRestaurantPizzaPriceRepository
    {
        public RestaurantPizzaPriceDto GetPizza(int restaurantId, int pizzaId);

        public IEnumerable<RestaurantPizzaPriceDto> GetForRestaurant(int restaurantId);
    }
}
