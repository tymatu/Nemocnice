using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.Models
{
    public class User : INotifyPropertyChanged
    {
        private int _userId;
        private string _username;
        private string _password;

        [Key]
        public int UserId
        {
            get => _userId;
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        [Required]
        [MaxLength(50)]
        public string UserName
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        [Required]
        [MaxLength(100)]
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
