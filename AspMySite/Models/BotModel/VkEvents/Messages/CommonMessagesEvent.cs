using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkEvents.Messages
{
    public class CommonMessagesEvent
    {
        public enum MessagesFlags
        {
            UnreadMessage = 1,  // 2 pow 0
            OutboxMessage = 2, 
            MessageReplied = 4,
            ImportantMessage = 8,
            MessageChatUnsafed = 16,
            MessageFromFriend = 32, 
            MessageSpam = 64, 
            MessageDeleted = 128,
            MessageCorrectFixedUnsafed = 256,
            MessageMediaUnsafed = 512,
            MessageWelcomeHidden = 65536,
            MessageDeleteForAll = 131072,
            MessageNotDevilered = 262144
        }

        public enum DialogFlas
        {
            important = 1,
            unanswered = 2
        }
    }
}