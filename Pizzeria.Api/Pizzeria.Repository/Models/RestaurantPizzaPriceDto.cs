namespace Pizzeria.Repositories.Models
{
    public class RestaurantPizzaPriceDto
    {
        public int PizzaId { get; set; }

        public int RestaurantId { get; set; }

        public decimal Price { get; set; }
    }
}
