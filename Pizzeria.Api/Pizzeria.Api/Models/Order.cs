using Pizzeria.Api.Repositories;

namespace Pizzeria.Api.Models
{
    public class Order
    {
        public int RestaurantId { get; set; }

        public IEnumerable<PizzaOrder> PizzaOrders { get; set; }

        public decimal CalculateTotalCost()
        {
            return PizzaOrders.Sum(p => p.GetCost(RestaurantId));
        }
    }

    public class PizzaOrder
    {
        public int PizzaId { get; set; }

        public IEnumerable<int> ToppingIds { get; set; }

        private readonly IRestaurantPizzaPriceRepository _restaurantPizzaPriceRepo;
        private readonly IToppingRepository _toppingRepository;

        public PizzaOrder(IRestaurantPizzaPriceRepository restaurantPizzaPriceRepo, IToppingRepository toppingRepository)
        {
            _restaurantPizzaPriceRepo = restaurantPizzaPriceRepo;
            _toppingRepository = toppingRepository;
        }

        public decimal GetCost(int restaurantId)
        {
            var pizzaCost = _restaurantPizzaPriceRepo.GetPizza(restaurantId, PizzaId).Price;
            var toppingCost = ToppingIds.Sum(t => _toppingRepository.Get(t).Price);
            return pizzaCost + toppingCost;
        }
    }
}
