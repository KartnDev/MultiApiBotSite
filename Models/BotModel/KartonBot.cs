using AspMySite.Models.BotModel.BotListener;
using AspMySite.Models.BotModel.BotListener.VkListener;
using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AspMySite.Models.BotModel.VkEvents.Messages.ChatMessagesEvents;
using static AspMySite.Models.BotModel.VkEvents.Messages.UserMessageEvents;

namespace AspMySite.Models.BotModel
{
    public class KartonBot
    {
        // Getting start and configuration...
        private string VkToken, TwitchToken, OsuToken;

        private List<SiteUser> AllSiteUsers;
        public KartonBot()
        {
            
            using (SiteContext context = new SiteContext())
            {
                AllSiteUsers = context.siteUsers.ToList();
            }
            
        }

        public void Run()
        {
            foreach (var userCase in AllSiteUsers)
            {
                using (SiteContext context = new SiteContext())
                {
                    var UserHandableInstanses = context.uUserSiteInstances.FirstOrDefault(u => u.userSiteId == userCase.ID);
                    if(UserHandableInstanses != null)
                    {
                        
                    }
                }
            }
        }

        private void ListenVkForCommands(List<int> chatIDs, List<VkCommands> vkCommands, string Token)
        {
            LongPollListener pollListener = new LongPollListener(Token, 25, 2);
            foreach(var vkEvent in pollListener.ListenLongPoolVk())
            {
                if(ChatMessage.isChatMessage(vkEvent))
                {
                    // ChatMessageController
                }
                if(UserMessage.isUserMessage(vkEvent))
                {
                    // UserMessageController
                }
            }
        }


    }
}