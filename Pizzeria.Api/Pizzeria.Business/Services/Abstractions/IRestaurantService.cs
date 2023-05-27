using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services.Abstractions
{
    public interface IRestaurantService
    {
        public IEnumerable<Restaurant> GetAll();

        public Restaurant Get(int id);
    }
}
