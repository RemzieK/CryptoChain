using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Entities
{
    public class Wallet
    {
        public Guid WalletId { get;}
        public Guid OwnerId { get; }
        public decimal RemcoinBalance { get; private set; }

        public Wallet(Guid walletId, Guid ownerId, decimal remcoinBalance)
        {
            WalletId = walletId;
            OwnerId = ownerId;
            RemcoinBalance = remcoinBalance;
        }

        internal void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Credit amount must be greater than zero.", nameof(amount));

            RemcoinBalance += amount;
        }
        internal void Debit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Debit amount must be greater than zero.", nameof(amount));
            else if (RemcoinBalance < amount)
                throw new InvalidOperationException("Insufficient balance");

            RemcoinBalance -= amount;
        }
        public decimal GetBalance() => RemcoinBalance;
    }
}
