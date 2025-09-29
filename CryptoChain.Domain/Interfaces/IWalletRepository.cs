using CryptoChain.Domain.Entities;

namespace CryptoChain.Domain.Interfaces
{
    public interface IWalletRepository
    {
        Wallet GetByOwnerId(Guid ownerId);
        Wallet GetById(Guid walletId);
        public void Add(Wallet wallet);
        public void Update(Wallet wallet);
    }
}
