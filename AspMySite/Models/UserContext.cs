using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspMySite.Models.SQLModel.DbTableModels;
using Microsoft.EntityFrameworkCore;

namespace AspMySite.Models
{
    public class UserContext : DbContext
    {
        public DbSet<SiteUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=ячс123;database=serverdb;");
        }
    }
}