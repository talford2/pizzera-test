using Pizzeria.Repository.Models;

namespace Pizzeria.Repository.Interfaces
{
	public interface IOrderRepository
	{
		public OrderDto? Get(int id);

		public int Create(OrderDto order);

		public void Delete(int id);
	}
}
