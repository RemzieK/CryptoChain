using ChryptoChain.Infrastructure.Repositories;
using CryptoChain.Application.Interfaces;
using CryptoChain.Domain.Interfaces;
using CryptoChain.Infrastructure.Database;
using CryptoChain.UI.View;
using CryptoChain.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace CryptoChain.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static IServiceProvider serviceProvider { get; private set; }
        public static IConfiguration configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            configuration = configurationBuilder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureService(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default connection")));

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            //services
            services.AddScoped<IAuthenticationService, IAuthenticationService>();
            services.AddScoped<IPasswordHashing, IPasswordHashing>();
            services.AddScoped<IAuthenticationService, IAuthenticationService>();
            // views
            services.AddScoped<MainWindow>();
            services.AddScoped<LoginView>();
            services.AddScoped<RegisterView>();
            //viewModels
            services.AddScoped<LoginViewModel>();
            services.AddScoped<RegisterViewModel>();
            services.AddScoped<ViewModelBase>();

        }
    }

}
