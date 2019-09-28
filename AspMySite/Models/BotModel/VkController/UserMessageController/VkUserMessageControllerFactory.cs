using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController.UserMessageController
{
    public class VkUserMessageControllerFactory : AbstractVkContorllersFactory
    {
        public override AbstractVkEventController CreateController(string token)
        {
            return new VkUserMessageController(token);
        }
    }
}