using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;
using OnlineStore.DAL.Settings;

namespace OnlineStore.DAL.Repositories
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(OnlineStoreDbContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Order>> GetAllUserOrdersAsync(int userId, PaginationSettings paginationSettings, CancellationToken cancellationToken)
		{
			return await _context.Set<Order>()
				.Where(o => userId == o.UserId)
				.Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
				.Take(paginationSettings.PageSize)
				.AsNoTracking()
				.ToListAsync(cancellationToken);
		}
    
    public async Task<Order> GetOrderByIdWithOrderItem(int id, CancellationToken cancellationToken)
    {
        return await _context.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
    }
	}
}


