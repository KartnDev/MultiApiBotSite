using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels
{
    public class ChatUser
    {
        public int ID { get; set; }
        public string VkName { get; set; }
        
        public int AtChatId { get; set; }
        public string Association1 { get; set; }

        public string Association2 { get; set; }

        public int VK_ID { get; set; }

        public bool isBotOp { get; set; }

        public bool isVkAdmin { get; set; }
    }
}