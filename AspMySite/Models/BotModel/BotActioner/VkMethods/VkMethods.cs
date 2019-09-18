using AspMySite.Models.BotModel.BotActioner.OsuMethods;
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

        private async Task VkMethodAsync(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            await RequestWebMethodAsync(connectionString);
        }

        private void VkMethod(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            RequestWebMethod(connectionString);
        }



        public async Task BanAsync(int userID, int seconds = 0, string reason = null)
        {
            throw new NotImplementedException();
        }

        public void Invite(int userID)
        {
            throw new NotImplementedException();
        }

        public Task InviteAsync(int userID)
        {
            throw new NotImplementedException();
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