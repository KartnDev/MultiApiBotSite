using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader;
using System.Threading.Tasks;
using AspMySite.Models.BotModel.BotListener.VkListener.VkWebApiReadMethods;

namespace AspMySite.Models.BotModel.BotListener.VkListener
{
    public class LongPollListener : VkReadApi
    {

       



        private static string longPollURL = "{$server}?act=a_check&key={$key}&ts={$ts}&wait=25&mode=2&version=2";
        private static int waitListenDelay = 25;
        private string ts = "NULL_TS";
        private string serverName = "NULL_TS";
        private string key = "NULL_TS";
        private string pts = "NULL_TS";


        public string messageException { get; private set; }
        public LongPollListener(string Token, int timeDelay, int version) : base(Token)
        {
            try
            {
                JObject MapArgs = (JObject)GetLongPollServer(3, true).GetValue("response");
                serverName = (string)MapArgs.GetValue("server");
                key = (string)MapArgs.GetValue("key");
                ts = (string)MapArgs.GetValue("ts");
                pts = (string)MapArgs.GetValue("pts");
                //longPollURL = $"{serverName}?act=a_check&key={key}&ts={ts}&wait={timeDelay}&mode=2&version={version}";
            }
            catch (Exception e)
            {
                messageException = e.Message;
                longPollURL = null;
            }
            

        }

        // TODO it must be private
        private JObject GetLongPollServer(int version, bool needPts=false)
        {
            /* version is a value from 1 to 3
            * correct version is 3
            * need pts is a boolean (1 or 0)
            * to get pts key
            * returns pts for vk method 'messages.getLongPollHistory'
            * */

            JObject serverApiPool = VkReadMethod("messages.getLongPollServer", $"lp_version={version}&need_pts={Convert.ToInt32(needPts)}");

            return serverApiPool;
        }


        //TODO observer here
        public IEnumerable<dynamic> ListenLongPoolVk()
        {
            while (true)
            {
                longPollURL = $"{serverName}?act=a_check&key={key}&ts={ts}&wait={waitListenDelay}&mode=2&version=3";
                dynamic update = ReadWebMethod(longPollURL);
                ts = (string)update.GetValue("ts");
                yield return update.GetValue("updates");
            }
        }





    }
}