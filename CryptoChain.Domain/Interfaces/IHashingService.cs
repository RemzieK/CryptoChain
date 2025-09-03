using CryptoChain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Interfaces
{
    public interface IHashingService
    {
        Hash ComputeHash(int index, DateTime timestamp, string data, Hash previousHash, int nonce);
    }
}
