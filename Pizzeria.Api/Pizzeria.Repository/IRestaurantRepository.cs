using Pizzeria.Repositories.Models;

namespace Pizzeria.Repository
{
    public interface IRestaurantRepository
    {
        public RestaurantDto? Get(int id);
    }
}
