using Pizzeria.Business.Models;

namespace Pizzeria.Business.Services.Abstractions
{
    public interface IOrderService
    {
        public Order Get(int id);

        public Order Create(int restaurantId, int pizzaId);

        public Order AddPizzaToOrder(int orderId, int pizzaId);
    }
}
