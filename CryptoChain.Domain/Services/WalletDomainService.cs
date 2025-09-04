using CryptoChain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Services
{
    public class WalletDomainService
    {
        public void MiningReward(Wallet wallet, decimal amount = 1)
        {
            wallet.Credit(amount);
        }
        public void Debit(Wallet wallet, decimal amount)
        {
            wallet.Debit(amount);
        }
    }
}
