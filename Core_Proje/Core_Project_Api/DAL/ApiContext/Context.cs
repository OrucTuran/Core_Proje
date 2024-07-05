using Core_Project_Api.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Project_Api.DAL.ApiContext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1FB5EJT\\SQLEXPRESS;database=CoreProjeDBApi;integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
