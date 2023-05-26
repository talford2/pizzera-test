namespace Pizzeria.Business.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; }

        public decimal BasePrice { get; set; }

        public string[] BaseIngredients { get; set; }
    }
}
