using AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AspMySite.Models.BotModel.BotListener.VkListener.VkWebApiReadMethods
{
    public class VkReadApi : ReadApiMethods
    {

        private static readonly string VkWebMethodURL = "api.vk.com/method/";

        private static readonly string VERSION = "5.101";

        public VkReadApi(string Token) : base(Token)
        {

        }

        // SafeMethods
        protected async Task<JObject> VkReadMethodAsync(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            return await TryReadWebMethodAsync(connectionString);
        }

        protected JObject VkReadMethod(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            return TryReadWebMethod(connectionString);
        }



    }
}