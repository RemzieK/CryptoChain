using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.ValueObjects;
using System.Security.Cryptography;
using System.Text;

namespace CryptoChain.Infrastructure.Hashing
{
    public class HashingService : IHashingService
    {
        public Hash ComputeHash(int index, DateTime timestamp, string data, Hash previousHash, int nonce)
        {
            using var sha256 = SHA256.Create();
            string input = $"{index}-{timestamp:o}-{data}-{previousHash}-{nonce}";
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(bytes);
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return new Hash(hashString);
        }
    }
}
