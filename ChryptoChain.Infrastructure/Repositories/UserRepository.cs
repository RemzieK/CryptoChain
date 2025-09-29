using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ChryptoChain.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            context.Users.Remove(user);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
