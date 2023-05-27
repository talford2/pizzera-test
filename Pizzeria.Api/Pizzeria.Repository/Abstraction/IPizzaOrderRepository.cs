using Pizzeria.Repository.Models;

namespace Pizzeria.Repository.Interfaces
{
    public interface IPizzaOrderRepository
    {
        public int Create(int orderId, int pizzaId);

        public IEnumerable<PizzaOrderDto> GetForOrder(int orderId);
    }
}
