using Microsoft.AspNetCore.Mvc;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public IEnumerable<Pizza> GetMenu(int restaurantId)
        {
            return _pizzaService.GetMenu(restaurantId);
        }
    }
}