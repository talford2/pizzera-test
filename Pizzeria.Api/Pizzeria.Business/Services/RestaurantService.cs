using Pizzeria.Business.Models;
using Pizzeria.Repository.Interfaces;

namespace Pizzeria.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantService)
        {
            _restaurantRepository = restaurantService;
        }

        public Restaurant Get(int id)
        {
            var r = _restaurantRepository.Get(id);
            return new Restaurant
            {
                Id = r.Id,
                Name = r.Name,
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantRepository.GetAll().Select(r => new Restaurant
            {
                Id = r.Id,
                Name = r.Name
            });
        }
    }
}
