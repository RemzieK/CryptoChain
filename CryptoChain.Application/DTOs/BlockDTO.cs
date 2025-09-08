using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Application.DTOs
{
    public class BlockDTO
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string Hash { get; set; } = string.Empty;
        public string PreviousHash { get; set; } = string.Empty;
        public List<TransactionDTO> Transactions { get; set; } = new();
    }
}
