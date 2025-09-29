using CryptoChain.Application.DTOs;

namespace CryptoChain.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task RegsiterAsync(RegisterRequestDTO registerDto);
        Task<UserDto> LoginAsync(LoginRequestDTO loginDto);
    }
}
