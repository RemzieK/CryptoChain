using CryptoChain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
