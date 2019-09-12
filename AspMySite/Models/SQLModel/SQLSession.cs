using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AspMySite.Models.SQLModel.DbTableModels;

namespace AspMySite.Models.SQLModel
{
    public class SQLSession : DbContext
    {
        public DbSet<VkUser> vkUsers { get; set; }
        public DbSet<SiteUser> siteUsers { get; set; }
        public DbSet<VkCommands> vkCommands { get; set; }

    }
}