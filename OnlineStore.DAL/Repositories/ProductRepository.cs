using System.Security.Cryptography.X509Certificates;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public async Task<Product> FindProductByCategory(string categoryName ,CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(x => x.CategoryName == categoryName).ToListAsync();
        }
    }
}
