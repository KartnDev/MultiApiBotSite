﻿using Newtonsoft.Json.Linq;
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
        private static string longPollURL = "{$server}?act=a_check&key={$key}&ts={$ts}&wait=25&mode=2&version=2";
        public string messageException { get; private set; }
        public LongPollMethod(string Token, int timeDelay, int version) : base(Token)
        {
            try
            {
                JObject MapArgs = (JObject)GetLongPollServer(3, true).GetValue("response");
                string serverName = (string)MapArgs.GetValue("server");
                string key = (string)MapArgs.GetValue("key");
                string ts = (string)MapArgs.GetValue("ts");
                string pts = (string)MapArgs.GetValue("pts");
                longPollURL = $"{serverName}?act=a_check&key={key}&ts={ts}&wait={timeDelay}&mode=2&version={version}";
            }
            catch (Exception e)
            {
                messageException = e.Message;
                longPollURL = null;
            }
            

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



        public JObject ReadLongPoolVk()
        {

            return ReadWebMethod(longPollURL); ;
        }





    }
}