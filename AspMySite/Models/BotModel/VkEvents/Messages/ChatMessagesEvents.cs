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
            private class UnderMessage
            {
                public int flag { get; set; }
                public int arg1 { get; set; }
                public int arg2 { get; set; }
                public int chatID { get; set; }
                public int arg4 { get; set; }
                public string message { get; set; }

                public Dictionary<string, string> userDict { get; set; }

                public Dictionary<JObject, JObject> arg7 { get; set; }

                }

            public JArray chatMessage;

            public bool IsChatMessage()
            {
                return false;
            }


        }
        public class UserTypingInChat
        {

        }
        public class EditChatMessage
        {

        }

        public class ExtraFields
        {

        }
    }
}