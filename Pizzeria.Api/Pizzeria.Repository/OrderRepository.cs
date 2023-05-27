using Pizzeria.Repository.Interfaces;
using Pizzeria.Repository.Models;

namespace Pizzeria.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private static List<OrderDto> _orders = new List<OrderDto> { };

        public int Create(OrderDto order)
        {
            var newId = _orders.Any() ? _orders.Max(o => o.Id) + 1 : 1;
            order.Id = newId;
            _orders.Add(order);
            return newId;
        }

        public OrderDto? Get(int id)
        {
            return _orders.SingleOrDefault(o => o.Id == id);
        }
    }
}
