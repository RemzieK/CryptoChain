namespace CryptoChain.Domain.Services
{
    public class PasswordValidator
    {
        public static Task<bool> IsValidAsync(string password)
        {
            bool isValid =
                !string.IsNullOrWhiteSpace(password) && password.Length >= 8 && password.Any(char.IsUpper) && password.Any(char.IsDigit);
            return Task.FromResult(isValid);
        }
    }
}
