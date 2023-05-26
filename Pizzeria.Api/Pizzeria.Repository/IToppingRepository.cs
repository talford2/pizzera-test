using Pizzeria.Repositories.Models;

namespace Pizzeria.Repository
{
    public interface IToppingRepository
    {
        public ToppingDto Get(int id);
    }
}
