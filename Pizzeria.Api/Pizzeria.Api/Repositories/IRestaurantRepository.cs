using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IRestaurantRepository
    {
        public Restaurant Get(int id);
    }
}
