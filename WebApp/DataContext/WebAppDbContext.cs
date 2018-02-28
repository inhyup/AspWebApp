using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.DataContext
{
    public class WebAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } 
        
        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=WebDb;User Id=sa;Password=qlcjsdjrjafb1;");   
        }

    }
}
