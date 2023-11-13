using Microsoft.EntityFrameworkCore;
using Nemocnice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nemocnice.Configuration
{
    public class DbConfig : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbConfig()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=nemocnice.db");
        }
        
    }
}
