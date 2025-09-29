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
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly INavigationService navigation;

        public IAsyncRelayCommand LoginCommand { get; }
        private string _email;
        private string _password;

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel(IAuthenticationService authenticationService, INavigationService nav)
        {
            this.authenticationService = authenticationService;
            nav = navigation;
            LoginCommand = new AsyncRelayCommand(LoginAsync);
        }
        private async Task LoginAsync()
        {
            try
            {
                var dto = new LoginRequestDTO
                {
                    Email = _email,
                    Password = _password
                };

                var user = await authenticationService.LoginAsync(dto);
                MessageBox.Show($"Welcome, {user.UserName}!");
                navigation.NavigateToMain();
            }
            catch(Exception ex ) 
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }
    }
}
