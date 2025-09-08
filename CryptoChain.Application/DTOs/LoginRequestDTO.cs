using System.ComponentModel.DataAnnotations;

namespace CryptoChain.Application.DTOs
{
    public class LoginRequestDTO
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
