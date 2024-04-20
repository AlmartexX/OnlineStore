using OnlineStore.DAL.Entities;

namespace OnlineStore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetAllOrdersByUserId(int userId, CancellationToken cancellationToken);
        Task<Order> GetOrderByIdWithOrderItem(int id, CancellationToken cancellationToken);
    }
}
