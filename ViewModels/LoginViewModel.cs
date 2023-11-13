using Nemocnice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Security;
using Nemocnice.Commands;
using Nemocnice.Configuration;
using Nemocnice.Services;

namespace Nemocnice.ViewModels
{
    public class LoginViewModel : ViewModelBase {

        //private User user;
        private string? _username;
        private string? _password;
        private string? _errorMsg;
        public ICommand LoginCommand { get; }
        private readonly LoginService db;
        private readonly INavigationService navigationService;
        public LoginViewModel(LoginService db,INavigationService navigationService)
        {
            LoginCommand = new ButtonClick(ExecuteMyCommand, CanExecuteMyCommand);
            this.navigationService = navigationService;
            this.db = db;
        }

        private void ExecuteMyCommand(object parameter)
        {

            User? user = db.CheckCredentials(UserName, Password);
            if (user == null)
            {
                ErrorMsg = "**Takový uživatel neexistuje, zkusťě znovu!**";
            }
            else
            {
                navigationService.CloseLoginWindow();
                navigationService.OpenMainWindow();
            }
        }

        private bool CanExecuteMyCommand(object parameter)
        {
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 2 ||
                Password == null || Password.Length < 2)
            {
               // MessageBox.Show($"Delka hesla a uživatelského jmena má být minimalní 2");
                return false;

            }
            return true;
        }
        public string? ErrorMsg
        {
            get
            {
                return _errorMsg;
            }

            set
            {
                _errorMsg = value;
                OnPropertyChanged(nameof(ErrorMsg));
            }
        }

        public string? UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    }
}
