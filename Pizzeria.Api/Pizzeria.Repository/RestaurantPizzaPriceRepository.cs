using Pizzeria.Repositories.Models;
using Pizzeria.Repository.Interfaces;

namespace Pizzeria.Repository
{
    public class RestaurantPizzaPriceRepository : IRestaurantPizzaPriceRepository
    {
        private static List<RestaurantPizzaPriceDto> _restaurantPizzaPrices = new List<RestaurantPizzaPriceDto>
        {
            new RestaurantPizzaPriceDto
            {
                RestaurantId = 111,
                PizzaId = 1,
                Price = 20
            },
            new RestaurantPizzaPriceDto
            {
                RestaurantId = 111,
                PizzaId = 2,
                Price = 18
            },
            new RestaurantPizzaPriceDto
            {
                RestaurantId = 111,
                PizzaId = 3,
                Price = 22
            },
            new RestaurantPizzaPriceDto
            {
                RestaurantId = 222,
                PizzaId = 1,
                Price = 25,
            },
            new RestaurantPizzaPriceDto
            {
                RestaurantId = 222,
                PizzaId = 4,
                Price = 17
            }
        };

        public IEnumerable<RestaurantPizzaPriceDto> GetForRestaurant(int restaurantId)
        {
            return _restaurantPizzaPrices.Where(p => p.RestaurantId == restaurantId);
        }

        public RestaurantPizzaPriceDto GetPizza(int restaurantId, int pizzaId)
        {
            return _restaurantPizzaPrices.Single(p => p.RestaurantId == restaurantId && p.PizzaId == pizzaId);
        }
    }
}
