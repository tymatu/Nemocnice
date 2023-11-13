using Nemocnice.Configuration;
using Nemocnice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.Services
{
    public class LoginService
    {
        private readonly DbConfig db;

        public LoginService(DbConfig db)
        {
            this.db = db;
        }

        public User? CheckCredentials(string username, string password)
        {
            User? user = db.Users.FirstOrDefault(user => user.UserName == username);
            if (user != null && user.Password == password) return user;
            return null;
        }
    }
}
