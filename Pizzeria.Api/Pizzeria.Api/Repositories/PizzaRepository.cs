using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private static List<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza {
                Id = 1,
                Name = "Capricciosa",
                BaseIngredients = new string[] { "Cheese", "Ham", "Mushroom", "Olive" }
            },
            new Pizza
            {
                Id = 2,
                Name = "Maxicana",
                BaseIngredients = new string[] { "Cheese", "Salami", "Capsicum", "Chilli" }
            },
            new Pizza
            {
                Id = 3,
                Name = "Margherita",
                BaseIngredients = new string[] { "Cheese", "Spinach", "Ricotta", "Cherry Tomatoes" }
            },
            new Pizza
            {
                Id = 4,
                Name = "Vegetarian",
                BaseIngredients = new string[] { "Cheese", "Mushrooms", "Capsicum", "Onion", "Olives" }
            }
        };

        public Pizza Get(int id)
        {
            return _pizzas.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _pizzas;
        }

        public void Add(Pizza pizza)
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
