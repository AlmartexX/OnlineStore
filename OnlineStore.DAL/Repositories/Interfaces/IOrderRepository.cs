using OnlineStore.DAL.Entities;

namespace OnlineStore.DAL.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetAllOrdersByUserId(int userId);
        Task<Order> GetOrderByIdWithOrderItem(int id);
    }
}
