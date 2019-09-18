using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMySite.Models.BotModel.BotActioner.VkMethods
{
    interface IVkMethods
    {
        void SendMessageTo(string message, string chatType, int id, string attachment=null);
        void SendMessageChat(string message, int userID, string attachment = null);
        void SendMessageUser(string message, int chatID, string attachment = null);

        Task SendMessageToAsync(string message, string chatType, int id, string attachment = null);
        Task SendMessageChatAsync(string message, int userID, string attachment = null);
        Task SendMessageUserAsync(string message, int chatID, string attachment = null);

        Task BanAsync(int userID, int seconds=0, string reason=null);

        void Invite(int userID);
        Task InviteAsync(int userID);
    }
}
