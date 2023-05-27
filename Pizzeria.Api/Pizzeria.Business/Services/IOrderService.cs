using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services
{
    public interface IOrderService
    {
        public Order Get(int id);

        public Order Create(int restaurantId, int pizzaId);
    }
}
