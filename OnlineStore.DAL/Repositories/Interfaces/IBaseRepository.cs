﻿using OnlineStore.DAL.Settings;

namespace OnlineStore.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(PaginationSettings paginationSettings, CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task AddAsync(TEntity item, CancellationToken cancellationToken);
        Task UpdateAsync(int id, TEntity item, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
