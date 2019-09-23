using AspMySite.Models.BotModel.BotActioner.VkMethods;
using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController
{
    
    public class VkChatController
    {
        private string VkToken;
        public VkChatController(string vkToken)
        {
            this.VkToken = vkToken;
        }

        public void ControlMessage(string message, List<VkCommands> commands, int chatID, List<ChatUser> chatUsers)
        {
            VkMethods vkMethods = new VkMethods(VkToken);
            BotComplexCommands.VkComplexCommands.VkCommands vkCommands = new BotComplexCommands.VkComplexCommands.VkCommands(VkToken);
            string[] args;

            foreach(var command in commands)
            {
                if (message == command.command)
                {
                    vkMethods.SendMessageChat(command.chatCommandValue, chatID, command.pictureValue);
                }
            }

            if(message.Contains(" "))
            {
                args = message.Split(" ".ToCharArray());

                string assosiation1 = chatUsers.FirstOrDefault()


                if(args[0] == "!ban")
                {
                    
                }
            }
        }


    }
}