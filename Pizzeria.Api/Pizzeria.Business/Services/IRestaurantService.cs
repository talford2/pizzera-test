using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAll();

        public Restaurant Get(int id);
    }
}
