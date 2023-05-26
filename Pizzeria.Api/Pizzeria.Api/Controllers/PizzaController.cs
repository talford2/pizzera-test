using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            return null;
        }
    }
}