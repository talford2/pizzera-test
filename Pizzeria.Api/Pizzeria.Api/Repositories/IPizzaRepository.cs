using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IPizzaRepository
    {
        public Pizza Get(int id);

        public IEnumerable<Pizza> GetAll();

        public void Add(Pizza pizza);

        public void Remove(int id);
    }
}
