using Pizzeria.Repositories.Models;

namespace Pizzeria.Repositories
{
    public interface IToppingRepository
    {
        public ToppingDto Get(int id);
    }
}
