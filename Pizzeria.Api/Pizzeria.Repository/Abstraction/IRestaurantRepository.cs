using Pizzeria.Repositories.Models;

namespace Pizzeria.Repository.Interfaces
{
    public interface IRestaurantRepository
    {
        public RestaurantDto? Get(int id);

        public IEnumerable<RestaurantDto> GetAll();
    }
}
