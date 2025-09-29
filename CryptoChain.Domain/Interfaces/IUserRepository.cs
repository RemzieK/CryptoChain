using CryptoChain.Domain.Entities;

namespace CryptoChain.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task SaveChangesAsync();
        Task DeleteUserAsync(User user);
    }
}
