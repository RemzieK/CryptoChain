using CommunityToolkit.Mvvm.Input;
using CryptoChain.Application.DTOs;
using CryptoChain.Application.Interfaces;
using CryptoChain.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoChain.UI.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        public IAuthenticationService AuthService => AuthService;
        private readonly IAuthenticationService _authService;
        private readonly INavigationService navigation;

        public IAsyncRelayCommand RegisterCommand { get; }

        private string email;
        private string userName;
        private string password;    

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public RegisterViewModel(IAuthenticationService authService, INavigationService navigation)
        {
            _authService = authService;
            this.navigation = navigation;
            RegisterCommand = new AsyncRelayCommand(RegisterAsync);
        }
        private async Task RegosterAsync()
        {
            try
            {
                var dto = new RegisterRequestDTO
                {
                    Email = email,
                    Name = userName,
                    Password = password
                };
                await _authService.RegsiterAsync(dto);
                MessageBox.Show("Registration successful");

                navigation.NavigateToMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration failed: {ex.Message}");
            }
        }
    }
}
