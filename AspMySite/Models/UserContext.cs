using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AspMySite.Models.SQLModel.DbTableModels;


namespace AspMySite.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("AppContext")
        {

        }
        public DbSet<SiteUser> Users { get; set; }

        
    }
}