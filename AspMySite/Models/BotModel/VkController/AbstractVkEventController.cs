using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController
{
    public abstract class AbstractVkEventController
    {
        protected string VkToken { get; private set; }
        public AbstractVkEventController(string vkToken)
        {
            this.VkToken = vkToken;
        }

        public abstract void ControlMessage(string message, List<VkCommands> commands, int chatID, List<ChatUser> chatUsers);


    }
}