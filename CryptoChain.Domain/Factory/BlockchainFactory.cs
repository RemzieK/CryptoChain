using CryptoChain.Domain.Aggregates;
using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Services;
using CryptoChain.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace CryptoChain.Domain.Factory
{
    public class BlockchainFactory
    {
        private readonly BlockFactory _blockFactory;
        private readonly MiningDomainService _miner;
        private readonly object _lock = new(); // ensures thread safety
        private Blockchain _blockchain;       // keeps reference to the blockchain

        public BlockchainFactory(BlockFactory blockFactory, MiningDomainService miner)
        {
            _blockFactory = blockFactory ?? throw new ArgumentNullException(nameof(blockFactory));
            _miner = miner ?? throw new ArgumentNullException(nameof(miner));
        }

        public Blockchain CreateBlockchain(Wallet minerWallet)
        {
            if (_blockchain != null)
                return _blockchain;

            lock (_lock)
            {
                if (_blockchain == null)
                {
                    // Genesis block has no transactions
                    var genesisBlock = _blockFactory.CreateBlock(0, new List<Transaction>(), new Hash("0"));

                    _miner.Mine(genesisBlock, minerWallet);

                    _blockchain = new Blockchain(genesisBlock);
                }
            }

            return _blockchain;
        }


        public Block AddNewBlock(List<Transaction> transactions, Wallet minerWallet)
        {
            if (_blockchain == null)
                throw new InvalidOperationException("Blockchain has not been created yet.");

            lock (_lock)
            {
                var previousHash = _blockchain.GetLatestBlock().Hash;

                // Create the block with transactions
                var newBlock = _blockFactory.CreateBlock(_blockchain.Blocks.Count, transactions, previousHash);

                // Mine the block (includes miner reward internally)
                _miner.Mine(newBlock, minerWallet);

                _blockchain.AddBlock(newBlock);

                return newBlock;
            }
        }


    }
}
