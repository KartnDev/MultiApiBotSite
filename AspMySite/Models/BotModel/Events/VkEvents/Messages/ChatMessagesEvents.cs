using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkEvents.Messages
{
    public class ChatMessagesEvents
    {
        public static readonly int CHAT_STARTTRACE = 2000000000;

        // chat id equals 2000000000 + $chat_id
        //for community group id + 1000000000

        public enum TypeId
        {
            ChangeNameChat = 1,
            ChangeIconChat = 2,
            AddedNewAdmin = 3,
            FixedMessage = 5,
            AddedNewUser = 6,
            UserLeftChat = 7,
            UserKicked = 8,
            RemovedFromAdmin = 9
        }


        /*
         * Info denends on type_id
         * --- Vk api docs ------
         * type_id = 1, 2 — $info = "0";
         * type_id = 3 — $info = "admin_id";
         * type_id = 5 — $info = "conversation_message_id";
         * type_id = 6, 7, 8, 9 — $info = "user_id";
         */
        public enum Info
        {
            NoInfoIf1Or2,
            GetAdminIdWhenType3,
            ConversionMessageIdIf5,
            UserIdIf4_5_6_7
        }
        

        public class ChatMessage
        {

            private JsonMessage message = null;

            public ChatMessage(dynamic JSON)
            {
                try
                {
                    message = new JsonMessage()
                    {
                        flag = int.Parse((string)JSON[0][0]),
                        arg1 = int.Parse((string)JSON[0][1]),
                        arg2 = int.Parse((string)JSON[0][2]),
                        chatID = int.Parse((string)JSON[0][3]),
                        arg4 = int.Parse((string)JSON[0][4]),
                        MessageValue = (string)JSON[0][5],
                        userDict = JSON[0][6],
                        userID = int.Parse((string)JSON[0][6].GetValue("from"))

                    };
                } catch(Exception e)
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
            public int GetChatIdAtMessage()
            {
                return message.chatID;
            }


            public static bool isChatMessage(dynamic item)
            {
                try
                {
                    JsonMessage message = new JsonMessage()
                    {
                        flag = int.Parse((string)item[0][0]),
                        arg1 = int.Parse((string)item[0][1]),
                        arg2 = int.Parse((string)item[0][2]),
                        chatID = int.Parse((string)item[0][3]),
                        arg4 = int.Parse((string)item[0][4]),
                        MessageValue = (string)item[0][5],
                        userDict = item[0][6],
                        userID = int.Parse((string)item[0][6].GetValue("from"))

                    };
                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }

            private class JsonMessage
            {
                public int flag { get; set; }
                public int arg1 { get; set; }
                public int arg2 { get; set; }
                public int chatID { get; set; }
                public int arg4 { get; set; }
                public string MessageValue { get; set; }

                public JObject userDict { get; set; }
                public JObject arg7 { get; set; }
                public int userID { get; set; }
                }

            public JArray chatMessage;

        }
        

    }
    public class UserTypingInChat
    {

    }
    public class EditChatMessage
    {

    }
}