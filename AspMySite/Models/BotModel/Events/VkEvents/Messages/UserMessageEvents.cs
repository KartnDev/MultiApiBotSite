using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkEvents.Messages
{
    public class UserMessageEvents
    {

        public class UserMessage
        {
            private JsonMessage message = null;

            public UserMessage(dynamic JSON)
            {
                try
                {
                    JsonMessage message = new JsonMessage()
                    {
                        flag = int.Parse((string)JSON[0][0]),
                        arg1 = int.Parse((string)JSON[0][1]),
                        arg2 = int.Parse((string)JSON[0][2]),
                        userID = int.Parse((string)JSON[0][3]),
                        arg4 = int.Parse((string)JSON[0][4]),
                        MessageValue = (string)JSON[0][5],
                        userDict = JSON[0][6],
                    };
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    throw new Exception("No ChatMessage identity... Try use other type");
                }
            }
            public string GetMessage()
            {
                return message.MessageValue;
            }
            public int GetSenderUserId()
            {
                return message.userID;
            }
            public int GetMessageFlag()
            {
                return message.flag;
            }


            public static bool isUserMessage(dynamic item)
            {
                try
                {
                    JsonMessage message = new JsonMessage()
                    {
                        flag = int.Parse((string)item[0][0]),
                        arg1 = int.Parse((string)item[0][1]),
                        arg2 = int.Parse((string)item[0][2]),
                        userID = int.Parse((string)item[0][3]),
                        arg4 = int.Parse((string)item[0][4]),
                        MessageValue = (string)item[0][5],
                        userDict = item[0][6],


                    };
                    return true;
                }
                catch (Exception e)
                {
                    e.GetType();
                    return false;
                }
            }


            private class JsonMessage
            {
                public int flag { get; set; }
                public int arg1 { get; set; }
                public int arg2 { get; set; }
                public int  userID { get; set; }
                public int arg4 { get; set; }
                public string MessageValue { get; set; }

                public JObject userDict { get; set; }
                public JObject arg7 { get; set; }

            }

            public JArray chatMessage;

            public bool IsChatMessage()
            {
                return false;
            }


        }


    }
}