using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController.ChatController
{
    public class VkChatControllerFactory : AbstractVkContorllersFactory
    {
        public override AbstractVkEventController CreateController(string token)
        {
            return new VkChatController(token);
        }
    }
}