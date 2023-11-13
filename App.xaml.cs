using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Nemocnice.Configuration;
using Nemocnice.Models;
using Nemocnice.Services;
using Nemocnice.ViewModels;
using Nemocnice.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nemocnice
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider? ServiceProvider { get; private set; }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<LoginViewModel>();
            services.AddSingleton<LoginView>(provider => new LoginView(provider.GetRequiredService<LoginViewModel>()));
            services.AddTransient<DbConfig>();
            services.AddTransient<LoginService>();
            services.AddSingleton<MainWindow>();


        }
        private void Start(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            DbConfig config = ServiceProvider.GetRequiredService<DbConfig>();
            Initialize(config);
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            Application.Current.MainWindow = mainWindow;


            var navigationMenu = ServiceProvider.GetRequiredService<INavigationService>();
            navigationMenu.OpenLoginWindow();
            

        }
        public static void Initialize(DbConfig context)
        {
            context.Database.EnsureCreated();

            //Inicializace data bazy
            if (!context.Users.Any())
            {
                context.Users.Add(new User { UserName = "admin", Password = "admin" });
                context.SaveChanges();
            }
        }
    }
}
