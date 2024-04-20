using OnlineStore.DAL.Entities;

namespace OnlineStore.DAL.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> FindProductsByCategory(string categoryName, CancellationToken cancellationToken);
    }
}
