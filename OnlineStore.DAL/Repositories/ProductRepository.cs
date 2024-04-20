using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> FindProductsByCategory(string categoryName, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.CategoryName == categoryName).ToListAsync();
        }
    }
}
