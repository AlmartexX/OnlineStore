using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Settings;

namespace OnlineStore.DAL.Repositories.Interfaces
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<IEnumerable<Order>> GetAllUserOrdersAsync(int userId, PaginationSettings paginationSettings, CancellationToken cancellationToken);
    Task<Order> GetOrderByIdWithOrderItem(int id, CancellationToken cancellationToken);
  }
}
