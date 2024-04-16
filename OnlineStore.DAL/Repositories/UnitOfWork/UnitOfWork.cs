using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OnlineStoreDbContext _context;

        public UnitOfWork(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public IProductRepository Products
        {
            get
            {
                return new ProductRepository(_context);
            }
        }

        public ICategoryRepository Categories
        {
            get
            {
                return new CategoryRepository(_context);
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                return new OrderRepository(_context);
            }
        }

        public IOrderItemRepository OrderItems
        {
            get
            {
                return new OrderItemRepository(_context);
            }
        }

        public IUserRepository Users
        {
            get
            {
                return new UserRepository(_context);
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
