namespace Pizzeria.Business.Models
{
    public class Order
    {
        public int Id { get; set; }

        public Restaurant? Restaurant { get; set; }

        public IEnumerable<PizzaOrder> PizzaOrders { get; set; }

        public decimal TotalCost => PizzaOrders.Sum(p => p.TotalCost);
    }
}
