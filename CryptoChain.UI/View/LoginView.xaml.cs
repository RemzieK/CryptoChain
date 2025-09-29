using CryptoChain.Application.Interfaces;
using CryptoChain.UI.Interfaces;
using CryptoChain.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CryptoChain.UI.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Page
    {
        private readonly IAuthenticationService authService;
        private readonly INavigationService navigation;
        public LoginView(IAuthenticationService authService, INavigationService navigation)
        {
            InitializeComponent();
            this.authService = authService;
            DataContext = new LoginViewModel(authService, navigation);
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void Register_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var registerPage = App.serviceProvider.GetRequiredService<RegisterView>();
            // Navigate to register page
            NavigationService?.Navigate(registerPage);
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }
    }
}
