using Microsoft.Extensions.DependencyInjection;
using Nemocnice.ViewModels;
using Nemocnice.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Nemocnice.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider serviceProvider;
        private LoginView loginView;

        
        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void CloseLoginWindow()
        {
            loginView.Close();
        }

        public void OpenLoginWindow()
        {
            loginView = serviceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }

        public void OpenMainWindow()
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow?.Show();
        }
    }
}
