using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Interfaces
{
    public interface IHashingService
    {
        Hash ComputeHash(int index, DateTime timestamp, string data, Hash previousHash, int nonce);
    }
}
