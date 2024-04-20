using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
       // IOrderRepository Orders { get; }
        //IOrderItemRepository OrderItems { get; }
        IUserRepository Users { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
