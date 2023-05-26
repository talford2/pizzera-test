using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private static List<Restaurant> _restaurants = new List<Restaurant>
        {
            new Restaurant
            {
                Id = 111,
                Location = "Preston"
            },
            new Restaurant
            {
                Id = 222,
                Location = "Southbank"
            }
        };

        public Restaurant Get(int id)
        {
            return _restaurants.SingleOrDefault(r => r.Id == id);
        }
    }
}
