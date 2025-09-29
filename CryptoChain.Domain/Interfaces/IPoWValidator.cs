using CryptoChain.Domain.Entities;

namespace CryptoChain.Domain.Interfaces
{
    public interface IPoWValidator
    {
        bool IsPoWValid(Block block);
    }
}
