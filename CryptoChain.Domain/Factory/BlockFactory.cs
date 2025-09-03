using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Factory
{
    public class BlockFactory
    {
        public Block CreateBlock(int index, string data, Hash previousHash)
        {
            var timestamps = DateTime.UtcNow;
            return new Block(index, timestamps, data, previousHash);
        }
    }
}
