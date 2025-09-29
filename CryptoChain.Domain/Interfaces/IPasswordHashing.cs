namespace CryptoChain.Domain.Interfaces
{
    public interface IPasswordHashing
    {
        Task<string> HashPasswordAsync(string password);
        Task<bool> VerifyPasswordAsync(string password, string hash);
    }
}
