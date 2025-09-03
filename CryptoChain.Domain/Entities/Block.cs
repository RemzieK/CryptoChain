using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Entities
{
    public class Block
    {
        public int Index { get;  }
        public DateTime Timestamp { get; }
        public string Data { get; } 
        public Hash PreviousHash { get; }
        public Hash Hash { get; private set; }
        public int Nonce { get; private set; }

        public Block(int index, DateTime timestamp, string data, Hash previousHash)
        {
            Index = index;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash ?? throw new ArgumentNullException(nameof(previousHash));
        }

        internal void SetHash(Hash hash, int nonce)
        {
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
            Nonce = nonce;
        }
    }
}
