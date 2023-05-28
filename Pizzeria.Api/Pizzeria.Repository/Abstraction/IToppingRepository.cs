using Pizzeria.Repositories.Models;

namespace Pizzeria.Repository.Interfaces
{
	public interface IToppingRepository
	{
		public ToppingDto Get(int id);

		public IEnumerable<ToppingDto> GetAll();
	}
}
