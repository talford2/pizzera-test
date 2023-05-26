using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IRestaurantPizzaPriceRepository
    {
        public RestaurantPizzaPrice GetPizza(int restaurantId, int pizzaId);

        public IEnumerable<RestaurantPizzaPrice> GetMenu(int restaurantId);
    }

    public class RestaurantPizzaPriceRepository : IRestaurantPizzaPriceRepository
    {
        private static List<RestaurantPizzaPrice> _restaurantPizzaPrices = new List<RestaurantPizzaPrice>
        {
            new RestaurantPizzaPrice
            {
                RestaurantId = 111,
                PizzaId = 1,
                Price = 20
            },
            new RestaurantPizzaPrice
            {
                RestaurantId = 111,
                PizzaId = 2,
                Price = 18
            },
            new RestaurantPizzaPrice
            {
                RestaurantId = 111,
                PizzaId = 3,
                Price = 22
            },
            new RestaurantPizzaPrice
            {
                RestaurantId = 222,
                PizzaId = 1,
                Price = 25,
            },
            new RestaurantPizzaPrice
            {
                RestaurantId = 222,
                PizzaId = 4,
                Price = 17
            }
        };

        public IEnumerable<RestaurantPizzaPrice> GetMenu(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public RestaurantPizzaPrice GetPizza(int restaurantId, int pizzaId)
        {
            return _restaurantPizzaPrices.SingleOrDefault(p => p.RestaurantId == restaurantId && p.PizzaId == pizzaId);
        }
    }
}
