using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IToppingRepository
    {
        public Topping Get(int id);
    }

    public class ToppingRepository : IToppingRepository
    {
        private static List<Topping> _toppings = new List<Topping>
        {
            new Topping
            {
                Id = 100,
                Name = "Cheese",
                Price = 1
            },
            new Topping
            {
                Id = 200,
                Name = "Capsicum",
                Price = 1
            },
            new Topping
            {
                Id = 300,
                Name = "Salami",
                Price = 1
            },
            new Topping
            {
                Id = 400,
                Name = "Olives",
                Price = 1
            }
        };

        public Topping Get(int id)
        {
            return _toppings.SingleOrDefault(t => t.Id == id);
        }
    }
}
