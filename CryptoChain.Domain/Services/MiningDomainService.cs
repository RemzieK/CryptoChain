using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Services
{
    public class MiningDomainService : IPoWValidator
    {
        private readonly IHashingService _hashingService;
        private readonly int _difficulty;

        public MiningDomainService(IHashingService hashingService, int difficulty = 2)
        {
            _hashingService = hashingService;
            _difficulty = difficulty;
        }

        public void Mine(Block block)
        {
            int nonce = 0;
            Hash hash;

            do
            {
                nonce++;
                hash = _hashingService.ComputeHash(block.Index, block.Timestamp, block.Data, block.PreviousHash, nonce);

            } while (!hash.Value.StartsWith(new string('0', _difficulty)));

            block.SetHash(hash, nonce);

        }
        public bool IsPoWValid(Block block)
        {
            if (block.Hash == null) return false;
            return block.Hash.Value.StartsWith(new string('0', _difficulty));
        }

    }
}
