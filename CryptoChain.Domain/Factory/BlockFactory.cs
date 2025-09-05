using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Factory
{
    public class BlockFactory
    {
        public Block CreateBlock(int index, List<Transaction> transactions, Hash previousHash)
        {
            return new Block(index, transactions, previousHash);
        }

    }
}
