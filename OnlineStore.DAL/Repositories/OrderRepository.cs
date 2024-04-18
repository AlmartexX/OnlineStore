using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetAllOrdersByUserId(int userId, CancellationToken cancellationToken)
        {
            return await _context.Orders.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Order> GetOrderByIdWithOrderItem(int id, CancellationToken cancellationToken)
        {
            return await _context.Orders.Include(x => x.OrderItems).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
