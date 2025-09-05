using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;

namespace CryptoChain.Domain.Services
{
    public class TransactionDomainService
    {
        private readonly IWalletRepository _walletRepository;

        public TransactionDomainService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
        }

        public Transaction CreateTransaction(Guid senderId, Guid receiverId, decimal amount)
        {
            if(senderId == receiverId)
                throw new ArgumentNullException("Sender and receiver cannot be the same.");
            if (amount <= 0)
                throw new ArgumentException("Amount muste be grater than zero.");

            var senderWallet = _walletRepository.GetByOwnerId(senderId);
            var receiverWallet = _walletRepository.GetByOwnerId(receiverId);

            senderWallet.Debit(amount);
            receiverWallet.Credit(amount);

            _walletRepository.Update(senderWallet);
            _walletRepository.Update(receiverWallet);

            var transaction = new Transaction(Guid.NewGuid(), senderId, receiverId,amount);
            return transaction;
        }
    }
}
