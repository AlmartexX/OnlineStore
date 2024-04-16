using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Context;
﻿using OnlineStore.DAL.Repositories.Interfaces;
using OnlineStore.DAL.Settings;

namespace OnlineStore.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly OnlineStoreDbContext _context;

        public BaseRepository(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken)
        {
            await _context.AddAsync(item, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var entityToDelete = await _context.FindAsync<TEntity>(id, cancellationToken);
            _context.Remove(entityToDelete);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(PaginationSettings paginationSettings, 
            CancellationToken cancellationToken) =>
            await _context.Set<TEntity>()
            CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>()
                .Skip((paginationSettings.PageNumber - 1) * paginationSettings.PageSize)
                .Take(paginationSettings.PageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.FindAsync<TEntity>(id, cancellationToken);
        }

        public async Task UpdateAsync(int id, TEntity item, CancellationToken cancellationToken)
        {
            var entityToUpdate = await _context.FindAsync<TEntity>(id, cancellationToken);
            _context.Entry<TEntity>(entityToUpdate).CurrentValues.SetValues(item);
        }
    }
}
