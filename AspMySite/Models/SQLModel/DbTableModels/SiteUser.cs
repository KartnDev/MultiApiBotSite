using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels
{
    public class SiteUser
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool SiteAdmin { get; set; }

    }
}