using AspMySite.Models.BotModel.BotActioner.VkMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspMySite.Models.BotModel.BotComplexCommands.VkComplexCommands
{
    public class VkCommands : ICommand
    {

        private string Token;
        public VkCommands(string Token)
        {
            this.Token = Token;
        }

        public void Ban(int userID, int chatID, int time = -1, string reason = null)
        {
            VkMethods vkMethods = new VkMethods(Token);
            if (reason != null)
            {
                vkMethods.SendMessageChat(reason + $"\nTimeout: {time}sec", chatID);
            }
            vkMethods.Kick(userID, chatID);
            Task.Delay(time*1000).ContinueWith((task) =>  { vkMethods.Invite(userID, chatID); }) ;
        }

        public void Chance(string message)
        {
            throw new NotImplementedException();
        }

        public void Roll(int lowerCase = 0, int upperCase = 100)
        {
            throw new NotImplementedException();
        }

        public void Time()
        {
            throw new NotImplementedException();
        }

    }
}