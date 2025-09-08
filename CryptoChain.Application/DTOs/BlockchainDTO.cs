using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Application.DTOs
{
    public class BlockchainDTO
    {
        public List<BlockDTO> Blocks { get; set; } = new();
    }
}
