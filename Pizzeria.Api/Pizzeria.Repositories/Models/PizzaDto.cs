namespace Pizzeria.Repositories.Models
{
    public class PizzaDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string[] BaseIngredients { get; set; }
    }
}
