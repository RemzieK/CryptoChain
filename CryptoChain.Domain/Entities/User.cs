using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChain.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? UserName { get; private set; }
        public string? Email { get; private set; }
        public string? PasswordHash {  get; private set; }

        public User(Guid userId, string userName, string email, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentException("Username cannot be empty.", nameof(userName));
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.", nameof(email));
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("PasswordHash cannot be empty.", nameof(passwordHash));

            UserId = userId;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
