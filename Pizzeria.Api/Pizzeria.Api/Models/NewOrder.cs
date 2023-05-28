namespace Pizzeria.Api.Models
{
	public class NewOrder
	{
		public int RestaurantId { get; set; }

		public int PizzaId { get; set; }

		public int[]? ToppingIds { get; set; }
	}
}
