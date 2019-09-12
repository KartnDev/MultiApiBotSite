using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels
{
    public class SiteContext : DbContext
    {
        public SiteContext(string ConnectionString) : base(ConnectionString)
        {

        }


        public DbSet<VkUser> vkUsers { get; set; }
        public DbSet<SiteUser> siteUsers { get; set; }
        public DbSet<VkCommands> vkCommands { get; set; }

    }
}