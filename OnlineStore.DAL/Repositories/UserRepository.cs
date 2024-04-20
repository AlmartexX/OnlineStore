using OnlineStore.DAL.Entities;
﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Entities;
using OnlineStore.DAL.Repositories.Interfaces;

namespace OnlineStore.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OnlineStoreDbContext context) : base(context)
        {

        }

        public async Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken)
        {
            var result = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);

            return result;
        }
    }
}
