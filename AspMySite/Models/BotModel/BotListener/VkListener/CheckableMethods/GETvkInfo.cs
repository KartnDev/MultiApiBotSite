using AspMySite.Models.BotModel.BotListener.VkListener.VkWebApiReadMethods;
using AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader;
using AspMySite.Models.SQLModel.DbTableModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspMySite.Models.BotModel.BotActioner.VkMethods.CheckableMethods
{
    public class GETvkInfo :VkReadApi
    {
        public GETvkInfo(string Token) : base(Token)
        {

        }


        public List<ChatUser> GetChatUsersList(int chatID)
        {
            JObject ChatInfo = (JObject)VkReadMethod("messages.getChat", $"chat_id={chatID}").GetValue("response");

            List<ChatUser> chatUsers = new List<ChatUser>();

              
        }

        public async Task<List<ChatUser>> GetChatUsersList()
        {



        }
    }
}