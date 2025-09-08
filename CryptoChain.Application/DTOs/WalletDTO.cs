using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Application.DTOs
{
    public class WalletDto
    {
        public Guid WalletId { get; set; }
        public Guid OwnerId { get; set; }
        public decimal Balance { get; set; }
    }
}
