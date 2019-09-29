using AspMySite.Models.BotModel.BotListener;
using AspMySite.Models.BotModel.BotListener.VkListener;
using AspMySite.Models.BotModel.VkController;
using AspMySite.Models.BotModel.VkController.ChatController;
using AspMySite.Models.BotModel.VkController.UserMessageController;
using AspMySite.Models.SQLModel.DbTableModels;
using AspMySite.Models.BotModel.BotActioner.VkMethods.CheckableMethods;
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
                    var UserVkInstanses = context.vkInstanses.FirstOrDefault(u => u.InstanceID == UserHandableInstanses.VkInstances);
                    List<VkCommands> UserVkCommands = context.vkCommands.ToList();
                    if (UserHandableInstanses != null)
                    {
                        // TODO Check for new list of useage(like shut downed bot etc
                        string[] chatIDSstringFormat = UserVkInstanses.dialogsHandlableList.Split(',');
                        List<int> chatIDsList = new List<int>();
                        foreach(string chatIdString in chatIDSstringFormat)
                        {
                            chatIDsList.Add(int.Parse(chatIdString));
                        }
                        ListenVkForCommands(chatIDsList, UserVkCommands, UserVkInstanses.Token);
                    }
                }
            }
        }


        


        private void ListenVkForCommands(List<int> chatIDs, List<VkCommands> vkCommands, string Token)
        {
            LongPollListener pollListener = new LongPollListener(Token, 25, 2);

            GETvkInfo GetterVk = new GETvkInfo(Token); 

            List<AbstractVkEventController> vkControllers = new List<AbstractVkEventController>();
            vkControllers.Add((new VkChatControllerFactory()).CreateController(Token));
            vkControllers.Add((new VkUserMessageControllerFactory()).CreateController(Token));

            // TODO Mayby some foreach loop for controllers?
            foreach (int correctChatID in chatIDs)
            {
                List<ChatUser> chatUsers = GetterVk.GetChatUsersList(correctChatID);

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