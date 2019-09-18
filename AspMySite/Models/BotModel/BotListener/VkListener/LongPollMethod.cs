using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader;
using System.Threading.Tasks;

namespace AspMySite.Models.BotModel.BotListener.VkListener
{
    public class LongPollMethod : ReadApiMethods
    {

        private static readonly string VkWebMethodURL = "api.vk.com/method/";
        private static readonly string longPollURL = "{$server}?act=a_check&key={$key}&ts={$ts}&wait=25&mode=2&version=2";
        public LongPollMethod(string Token) : base(Token)
        {

        }
        private static readonly string VERSION = "5.101";
      
        // SafeMethods
        private async Task<JObject> VkReadMethodAsync(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            return await TryReadWebMethodAsync(connectionString);
        }

        private JObject VkReadMethod(string methodName, string argsLine)
        {
            string connectionString = string.Format(VkWebMethodURL + $"{methodName}?" + argsLine + $"&access_token={Token}&v={VERSION}");
            return TryReadWebMethod(connectionString);
        }






        public JObject GetLongPollServer(string version)
        {
            /* version is a value from 1 to 3
            * correct version is 3
            * need pts is a boolean (1 or 0)
            * to get pts key
            * returns pts for vk method 'messages.getLongPollHistory'
            * */

            JObject serverApiPool = VkReadMethod("groups.getLongPollServer", $"lp_version={version}&need_pts=1");

            return serverApiPool;
        }



        public string ReadLongPoolVk()
        {








            return "";
        }





    }
}