using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels
{
    public class VkCommands
    {
        public int VkInstanceID { get; set; }
        public string command { get; set; }
        public string chatCommandValue { get; set; }
        public string pictureValue { get; set; }
    }
}