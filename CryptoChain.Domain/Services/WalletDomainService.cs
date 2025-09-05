using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;

namespace CryptoChain.Domain.Services
{
    public class WalletDomainService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletDomainService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }


        public void Credit(Wallet wallet, decimal amount = 1)
        {
            if (wallet == null) throw new ArgumentNullException(nameof(wallet));
            wallet.Credit(amount);
            _walletRepository.Update(wallet);
        }

        public void Debit(Wallet wallet, decimal amount)
        {
            if (wallet == null) throw new ArgumentNullException(nameof(wallet));
            wallet.Debit(amount);
            _walletRepository.Update(wallet);
        }

        public decimal GetBalance(Wallet wallet)
        {
            if (wallet == null) throw new ArgumentNullException(nameof(wallet));
            return wallet.GetBalance();
        }
    }

}
