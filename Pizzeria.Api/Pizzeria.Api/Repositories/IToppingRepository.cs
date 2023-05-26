using Pizzeria.Api.Models;

namespace Pizzeria.Api.Repositories
{
    public interface IToppingRepository
    {
        public Topping Get(int id);
    }
}
