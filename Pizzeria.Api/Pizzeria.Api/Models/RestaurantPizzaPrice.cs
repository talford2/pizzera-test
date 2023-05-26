namespace Pizzeria.Api.Models
{
    public class RestaurantPizzaPrice
    {
        public int PizzaId { get; set; }

        public int RestaurantId { get; set; }

        public decimal Price { get; set; }
    }
}
