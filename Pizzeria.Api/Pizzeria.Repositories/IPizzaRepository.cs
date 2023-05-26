using Pizzeria.Repositories.Models;

namespace Pizzeria.Repositories
{
    public interface IPizzaRepository
    {
        public PizzaDto Get(int id);

        public IEnumerable<PizzaDto> GetAll();

        public void Add(PizzaDto pizza);

        public void Remove(int id);
    }
}
