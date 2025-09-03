using CryptoChain.Domain.Aggregates;
using CryptoChain.Domain.Services;
using CryptoChain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Factory
{
    public class BlockchainFactory
    {
        private readonly BlockFactory _blockFactory;
        private readonly MiningDomainService _miner;

        public BlockchainFactory(BlockFactory blockFactory, MiningDomainService miner)
        {
            _blockFactory = blockFactory;
            _miner = miner;
        }

        public void AddNewBlock(Blockchain blockchain, string data)
        {
            var previousHash = blockchain.GetLatestBlock().Hash;
            var newBlock = _blockFactory.CreateBlock(blockchain.Blocks.Count, data, previousHash);

            _miner.Mine(newBlock);

            blockchain.AddBlock(newBlock);
        }

        public Blockchain CreateBlockchain(int difficulty)
        {
            var genesisBlock = _blockFactory.CreateBlock(0, "Genesis Block", new Hash("0"));
            _miner.Mine(genesisBlock);

            return new Blockchain(genesisBlock);
        }
    }

}
