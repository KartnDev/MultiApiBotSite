using AspMySite.Models.BotModel.BotActioner.VkMethods;
using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController
{

    public class VkChatController : AbstractVkEventController
    {
        public VkChatController(string vkToken) : base(vkToken)
        {
        }

        public override void ControlMessage(string message, List<VkCommands> commands, int chatID, List<ChatUser> chatUsers)
        {
            VkMethods vkMethods = new VkMethods(VkToken);
            BotComplexCommands.VkComplexCommands.VkCommands vkCommands = new BotComplexCommands.VkComplexCommands.VkCommands(VkToken);
            string[] args;

            try
            {
                foreach (var command in commands)
                {
                    if (message == command.command)
                    {
                        vkMethods.SendMessageChat(command.chatCommandValue, chatID, command.pictureValue);
                    }
                }

                if (message.Contains(" "))
                {
                    args = message.Split(" ".ToCharArray());
                    int AssosiatToID = 0;
                    bool haveAssosiation = false;
                    try
                    {
                        int.Parse(args[1]);
                    }
                    catch (Exception e)
                    {
                        foreach (var assosiatName in chatUsers)
                        {
                            if (assosiatName.Association1 == args[1] || assosiatName.Association2 == args[1])
                            {
                                haveAssosiation = true;
                                AssosiatToID = assosiatName.ID;
                            }
                        }
                    }
                    if (args[0] == "!ban" && args.Length >= 2)
                    {
                        int id = 0;
                        if (haveAssosiation && AssosiatToID != 0)
                        {
                            id = AssosiatToID;
                        }
                        else
                        {
                            
                            id = int.Parse(args[1]);
                        }
                        if (args.Length == 2)
                        {
                            vkCommands.Ban(id, chatID);
                        }
                        else if (args.Length == 3)
                        {
                            vkCommands.Ban(id, chatID, int.Parse(args[2]));
                        }
                        else if (args.Length == 4)
                        {
                            string reason = "";
                            for (int i = 2; i < args.Length; i++)
                            {
                                reason += args[i] + " ";
                            }
                            vkCommands.Ban(AssosiatToID, chatID, int.Parse(args[2]), args[4]);
                        }

                    }
                    if (args[0] == "!invite" && args.Length == 2)
                    {
                        int id = 0;
                        if (haveAssosiation && AssosiatToID != 0)
                        {
                            id = AssosiatToID;
                        }
                        else
                        {
                            id = int.Parse(args[1]);
                        }
                        vkMethods.Invite(id, chatID);
                    }
                    if (args[0] == "!chance" && args.Length >= 2)
                    {
                        throw new NotImplementedException();
                    }
                    if(args[0] == "!roll" && args.Length == 1)
                    {
                        throw new NotImplementedException();
                    }
                }

            }
            catch (Exception e)
            {
                vkMethods.SendMessageChat($"Ошибка при работе с командой.. StackTrace: {e.StackTrace}", chatID);
            }
        }

    }
}