using AspMySite.Models.BotModel.BotActioner.OsuMethods;
using AspMySite.Models.SQLModel.DbTableModels;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspMySite.Models.BotModel.BotActioner.VkMethods
{

    public class VkMethods : ReqWebMethod, IVkMethods
    {
        private static readonly string VkWebMethodURL = "api.vk.com/method/";
        private static readonly string VERSION = "5.101";
        public VkMethods(string Token) : base(Token)
        {

        }
        // SafeMethods
        private async Task VkMethodAsync(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            await TryRequestWebMethodAsync(connectionString);
        }

        private void VkMethod(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            TryRequestWebMethod(connectionString);
        }

        public void Kick(int userID, int chatID)
        {
            string args = string.Format($"chat_id={chatID}&user_id={userID}");
            VkMethod("messages.removeChatUser", args);
        }
        public async Task KickAsync(int userID,int chatID)
        {
            string args = string.Format($"chat_id={chatID}&user_id={userID}");
            await VkMethodAsync("messages.removeChatUser", args);
        }

        public void Invite(int userID, int chatID)
        {
            string args = string.Format($"chat_id={chatID}&user_id={userID}");
            VkMethod("messages.addChatUser", args);
        }

        public async Task InviteAsync(int userID, int chatID)
        {
            string args = string.Format($"chat_id={chatID}&user_id={userID}");
            await VkMethodAsync("messages.addChatUser", args);
        }

        public void SendMessageChat(string message, int chatID, string attachment = null)
        {
            SendMessageTo(message, "chat_id", chatID, attachment);
        }

        public async Task SendMessageChatAsync(string message, int chatID, string attachment = null)
        {
            await SendMessageToAsync(message, "chat_id", chatID, attachment);
        }

        public void SendMessageTo(string message, string chatType, int id, string attachment = null)
        {

            string args = string.Format($"{chatType}={id}&random_id={(new Random()).Next()}&message={message}");
            if (attachment != null)
            {
                args += $"&attachmen={attachment}";
            }

            VkMethod("messages.send", args);

        }

        public async Task SendMessageToAsync(string message, string chatType, int id, string attachment = null)
        {
            string args = string.Format($"{chatType}={id}&random_id={(new Random()).Next()}&message={message}");
            if (attachment != null)
            {
                args += $"&attachmen={attachment}";
            }

            await VkMethodAsync("messages.send", args);
        }

        public void SendMessageUser(string message, int userID, string attachment = null)
        {
            SendMessageTo(message, "user_id", userID, attachment);
        }

        public async Task SendMessageUserAsync(string message, int userID, string attachment = null)
        {
            await SendMessageToAsync(message, "user_id", userID, attachment);
        }



    }
}