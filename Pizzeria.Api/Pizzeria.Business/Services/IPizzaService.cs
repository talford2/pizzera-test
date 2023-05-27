using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services
{
    public interface IPizzaService
    {
        public IEnumerable<Pizza> GetMenu(int restaurantId);

        public Pizza GetPizza(int id);
    }
}
