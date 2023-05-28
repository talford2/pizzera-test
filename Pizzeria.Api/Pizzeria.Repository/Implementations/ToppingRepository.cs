using Pizzeria.Repositories.Models;
using Pizzeria.Repository.Interfaces;

namespace Pizzeria.Repository.Implementations
{
	public class ToppingRepository : IToppingRepository
	{
		private static List<ToppingDto> _toppings = new List<ToppingDto>
		{
			new ToppingDto
			{
				Id = 100,
				Name = "Cheese",
				Price = 1
			},
			new ToppingDto
			{
				Id = 200,
				Name = "Capsicum",
				Price = 1
			},
			new ToppingDto
			{
				Id = 300,
				Name = "Salami",
				Price = 1
			},
			new ToppingDto
			{
				Id = 400,
				Name = "Olives",
				Price = 1
			}
		};

		public ToppingDto Get(int id)
		{
			return _toppings.Single(t => t.Id == id);
		}

		public IEnumerable<ToppingDto> GetAll()
		{
			return _toppings;
		}
	}
}
