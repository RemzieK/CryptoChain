using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Services
{
    public class HashingDomainService : IHashingService
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
