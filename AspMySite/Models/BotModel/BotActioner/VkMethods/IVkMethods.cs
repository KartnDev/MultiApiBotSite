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
        void SendMessageChat(string message, int chatID, string attachment = null);
        void SendMessageUser(string message, int userID, string attachment = null);

        Task SendMessageToAsync(string message, string chatType, int id, string attachment = null);
        Task SendMessageChatAsync(string message, int chatID, string attachment = null);
        Task SendMessageUserAsync(string message, int userID, string attachment = null);


        void Kick(int userID, int chatID);
        Task KickAsync(int userID,int chatID);

        void Invite(int userID, int chatID);
        Task InviteAsync(int userID, int chatID);
    }
}
