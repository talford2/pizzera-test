namespace Pizzeria.Api.Models
{
    public class AddPizzaToOrder
    {
        public int OrderId { get; set; }

        public int PizzaId { get; set; }
    }
}
