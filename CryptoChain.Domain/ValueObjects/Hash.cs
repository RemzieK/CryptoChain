using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.ValueObjects
{
    public class Hash
    {
        public string Value { get; }

        public Hash(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Hash can't be empty", nameof(value));
            Value = value;
        }
        public override string ToString() => Value;
       
    }
}
