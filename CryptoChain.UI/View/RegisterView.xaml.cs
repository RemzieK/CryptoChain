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
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {
        private readonly RegisterViewModel viewModel;
        private readonly IAuthenticationService authService;
        private readonly INavigationService navigation;

        public RegisterView(IAuthenticationService authService, INavigationService navigation)
        {
            InitializeComponent();
            viewModel = new RegisterViewModel(authService, navigation);
            DataContext = viewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            viewModel.RegisterCommand.Execute(null);
        }

        private void btnCloseReg_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimizeReg_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
            }
        }

        private void Login_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var loginPage = App.serviceProvider.GetRequiredService<LoginView>();
            NavigationService?.Navigate(loginPage);
        }
    }
}
