using Pizzeria.Repositories.Models;

namespace Pizzeria.Repositories
{
    public interface IRestaurantRepository
    {
        public RestaurantDto Get(int id);
    }
}
