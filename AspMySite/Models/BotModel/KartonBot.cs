using AspMySite.Models.BotModel.BotListener;
using AspMySite.Models.BotModel.BotListener.VkListener;
using AspMySite.Models.BotModel.VkController;
using AspMySite.Models.BotModel.VkController.ChatController;
using AspMySite.Models.BotModel.VkController.UserMessageController;
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

        private void ListenVkForCommands(List<int> chatIDs, List<VkCommands> vkCommands, string Token, List<ChatUser> chatUsers)
        {
            LongPollListener pollListener = new LongPollListener(Token, 25, 2);

            List<AbstractVkEventController> vkControllers = new List<AbstractVkEventController>();
            vkControllers.Add((new VkChatControllerFactory()).CreateController(Token));
            vkControllers.Add((new VkUserMessageControllerFactory()).CreateController(Token));

            // TODO Mayby some foreach loop for controllers?
            foreach (int correctChatID in chatIDs)
            {
                foreach (var vkEvent in pollListener.ListenLongPoolVk())
                {
                    if (ChatMessage.isChatMessage(vkEvent))
                    {
                        ChatMessage chatMessage = new ChatMessage(vkEvent);
                        vkControllers[0].ControlMessage(chatMessage.GetMessage(), vkCommands, correctChatID, chatUsers);
                    }
                    if (UserMessage.isUserMessage(vkEvent))
                    {
                        UserMessage userMessage = new UserMessage(vkEvent);
                        vkControllers[0].ControlMessage(userMessage.GetMessage(), vkCommands, correctChatID, chatUsers);
                    }
                }
            }
        }


    }
}