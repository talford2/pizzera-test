using Pizzeria.Repositories.Models;
using Pizzeria.Repository.Interfaces;

namespace Pizzeria.Repository.Implementations
{
    public class PizzaRepository : IPizzaRepository
    {
        private static List<PizzaDto> _pizzas = new List<PizzaDto>
        {
            new PizzaDto {
                Id = 1,
                Name = "Capricciosa",
                BaseIngredients = new string[] { "Cheese", "Ham", "Mushroom", "Olive" }
            },
            new PizzaDto
            {
                Id = 2,
                Name = "Maxicana",
                BaseIngredients = new string[] { "Cheese", "Salami", "Capsicum", "Chilli" }
            },
            new PizzaDto
            {
                Id = 3,
                Name = "Margherita",
                BaseIngredients = new string[] { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" }
            },
            new PizzaDto
            {
                Id = 4,
                Name = "Vegetarian",
                BaseIngredients = new string[] { "Cheese", "Mushrooms", "Capsicum", "Onion", "Olives" }
            }
        };

        public PizzaDto Get(int id)
        {
            return _pizzas.Single(p => p.Id == id);
        }

        public IEnumerable<PizzaDto> GetAll()
        {
            return _pizzas;
        }

        public void Add(PizzaDto pizza)
        {
            pizza.Id = _pizzas.Max(p => p.Id) + 1;
            _pizzas.Add(pizza);
        }

        public void Remove(int id)
        {
            _pizzas.RemoveAll(p => p.Id == id);
        }
    }
}
