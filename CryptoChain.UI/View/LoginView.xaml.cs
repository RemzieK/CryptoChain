using CryptoChain.Application.Interfaces;
using CryptoChain.UI.Interfaces;
using CryptoChain.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            var registerWindow = App.ServiceProvider.GetRequiredService<RegisterView>();
            registerWindow.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.State = WindowState.Minimized;
        }
    }
}
