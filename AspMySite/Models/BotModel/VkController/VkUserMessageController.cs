using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController
{
    public class VkUserMessageController
    {
        private string token;

        public VkUserMessageController(string token)
        {
            this.token = token;
        }
    }
}