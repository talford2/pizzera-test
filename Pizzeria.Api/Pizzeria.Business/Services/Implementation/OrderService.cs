using Pizzeria.Business.Exceptions;
using Pizzeria.Business.Models;
using Pizzeria.Business.Services.Abstractions;
using Pizzeria.Repository.Interfaces;
using Pizzeria.Repository.Models;

namespace Pizzeria.Business.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPizzaOrderRepository _pizzaOrderRepository;

        private readonly IRestaurantService _restaurantService;
        private readonly IPizzaService _pizzaService;

        public OrderService(IOrderRepository orderRepository, IPizzaOrderRepository pizzaOrderRepository, IRestaurantService restaurantService, IPizzaService pizzaService)
        {
            _orderRepository = orderRepository;
            _pizzaOrderRepository = pizzaOrderRepository;
            _restaurantService = restaurantService;
            _pizzaService = pizzaService;
        }

        // Order always starts with 1 pizza
        public Order Create(int restaurantId, int pizzaId)
        {
            var newOrderId = _orderRepository.Create(new OrderDto { RestaurantId = restaurantId });
            var restaurant = _restaurantService.Get(restaurantId);
            var pizzaOrderId = _pizzaOrderRepository.Create(newOrderId, pizzaId);

            return new Order
            {
                Id = newOrderId,
                PizzaOrders = new List<PizzaOrder> {
                    new PizzaOrder {
                        Id = pizzaOrderId,
                        Pizza = _pizzaService.GetPizza(restaurantId, pizzaId)
                    }
                },
                Restaurant = restaurant
            };
        }

        public Order Get(int id)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
                throw new UnknownOrderException(id);

            var restaurant = _restaurantService.Get(order.RestaurantId);
            var pizzaOrders = _pizzaOrderRepository.GetForOrder(order.Id);

            return new Order
            {
                Id = id,
                Restaurant = restaurant,
                PizzaOrders = pizzaOrders.Select(o => new PizzaOrder
                {
                    Id = o.Id,
                    Pizza = _pizzaService.GetPizza(restaurant.Id, o.PizzaId),
                    // ExtraToppings = ????
                })
            };
        }

        public void AddPizzaToOrder(int orderId, int pizzaId)
        {
            _pizzaOrderRepository.Create(orderId, pizzaId);
        }

        public void RemovePizzaFromOrder(int pizzaOrderId)
        {
            _pizzaOrderRepository.Delete(pizzaOrderId);
        }
    }
}
