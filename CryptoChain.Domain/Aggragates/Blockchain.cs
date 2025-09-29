using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;

namespace CryptoChain.Domain.Aggregates
{
    public class Blockchain
    {
        private readonly List<Block> _chain;
        public IReadOnlyList<Block> Blocks => _chain.AsReadOnly();

        public Blockchain(Block genesisBlock)
        {
            if (genesisBlock == null)
                throw new ArgumentNullException(nameof(genesisBlock));

            _chain = new List<Block> { genesisBlock };
        }

        public Block GetLatestBlock() => _chain.Last();

        public void AddBlock(Block newBlock)
        {
            if (newBlock == null)
                throw new ArgumentNullException(nameof(newBlock));

            ValidateBlock(newBlock);
            _chain.Add(newBlock);
        }

        private void ValidateBlock(Block block)
        {
            var latestBlock = GetLatestBlock();

            if (block.PreviousHash.Value != latestBlock.Hash.Value)
                throw new InvalidOperationException("Previous hash mismatch.");

            if (block.Index != latestBlock.Index + 1)
                throw new InvalidOperationException("Invalid block index.");
        }


        public bool IsValidChain(IPoWValidator poWValidator)
        {
            for (int i = 1; i < _chain.Count; i++)
            {
                var current = _chain[i];
                var previous = _chain[i - 1];

                if (current.PreviousHash.Value != previous.Hash.Value)
                    return false;

                if (!poWValidator.IsPoWValid(current))
                    return false;
            }
            return true;
        }
    }
}
