using CryptoChain.Application.DTOs;
using CryptoChain.Application.Interfaces;
using CryptoChain.Domain.Entities;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Domain.Services;

namespace CryptoChain.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashing _passwordHashing;

        public AuthenticationService(IUserRepository userRepository, IPasswordHashing passwordHashing)
        {
            _userRepository = userRepository;
            _passwordHashing = passwordHashing;
        }
        public async Task<UserDto> LoginAsync(LoginRequestDTO login)
        {
            var user = await _userRepository.GetUserByEmailAsync(login.Email);
            if (user == null) throw new Exception("Invalid credentials");

            bool passwordMatch = await _passwordHashing.VerifyPasswordAsync(login.Password, user.PasswordHash);
            if (!passwordMatch) throw new Exception("Invalid credentials");

            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public async Task RegsiterAsync(RegisterRequestDTO register)
        {
            if (!await PasswordValidator.IsValidAsync(register.Password)) throw new Exception("Password doesn't meet requirements");

            var userExists = await _userRepository.GetUserByEmailAsync(register.Email);
            if (userExists != null) throw new Exception("User already exisits");

            var hash = await _passwordHashing.HashPasswordAsync(register.Password);

            var newUser = new User
            {
                UserName = register.Name,
                Email = register.Email,
                PasswordHash = hash
            };

            await _userRepository.AddUserAsync(newUser);
            await _userRepository.SaveChangesAsync();   

        }
    }
}
