using CryptoChain.Domain.ValueObjects;

namespace CryptoChain.Domain.Entities
{
    public class Block
    {
        public int Index { get; private set; }
        public DateTime Timestamp { get; private set; }
        public string Data { get; private set; } 
        public Hash PreviousHash { get; private set; }
        public Hash Hash { get; private set; }
        public int Nonce { get; private set; }

        public Block(int index, DateTime timestamp, string data, Hash previousHash)
        {
            Index = index;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash ?? throw new ArgumentNullException(nameof(previousHash));
        }

        public void SetHash(Hash hash, int nonce)
        {
            Hash = hash ?? throw new ArgumentNullException(nameof(hash));
            Nonce = nonce;
        }
    }
}
