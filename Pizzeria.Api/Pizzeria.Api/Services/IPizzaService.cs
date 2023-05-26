using Pizzeria.Api.Models;

namespace Pizzeria.Api.Services
{
    public interface IPizzaService
    {
        public IEnumerable<RestaurantPizzaPrice> GetPizzasForLocation(int restaurantId);
    }
}
