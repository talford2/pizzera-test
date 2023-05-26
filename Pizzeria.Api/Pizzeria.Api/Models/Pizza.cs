namespace Pizzeria.Api.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] BaseIngredients { get; set; }
    }
}
