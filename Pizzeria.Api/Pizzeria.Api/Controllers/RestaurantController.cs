using Microsoft.AspNetCore.Mvc;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("/restaurant")]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return _restaurantService.GetAll();
        }

        [HttpGet("/restaurant/{id}")]
        public Restaurant GetRestaurant(int id)
        {
            return _restaurantService.Get(id);
        }
    }
}
