using AspMySite.Models.SQLModel.DbTableModels.SiteModelUsers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels
{
    public class SiteContext : DbContext
    {
        public SiteContext() : base("AppContext")
        {

        }
        public DbSet<UserSiteInstances> uUserSiteInstances { get; set; }
        public DbSet<vkInstanses> vkInstanses { get; set; }
        public DbSet<ChatUser> vkUsers { get; set; }
        public DbSet<SiteUser> siteUsers { get; set; }
        public DbSet<VkCommands> vkCommands { get; set; }

    }
}