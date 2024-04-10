using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order(OnlineStoreDbContext context) : base(context)
        {
        }
    }
}
