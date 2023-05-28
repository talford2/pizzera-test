using Microsoft.AspNetCore.Mvc;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("restaurant/{restaurantId}/pizza")]
        public IEnumerable<Pizza> GetMenu(int restaurantId)
        {
            return _pizzaService.GetMenu(restaurantId);
        }

		[HttpGet("toppings")]
		public IEnumerable<Topping> GetToppings()
		{
			return _pizzaService.GetToppings();
		}
	}
}