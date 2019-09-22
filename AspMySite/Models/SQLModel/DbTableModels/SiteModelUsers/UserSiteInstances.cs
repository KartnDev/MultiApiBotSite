 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels.SiteModelUsers
{
    public class UserSiteInstances
    {
        public int userSiteId { get; set; }
        public int VkInstances { get; set; }
        public int TwitchInstanses { get; set; }
        public int OsuInstanses { get; set; }
    }
}