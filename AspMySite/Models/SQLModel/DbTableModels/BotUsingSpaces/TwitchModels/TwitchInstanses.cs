using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.DbTableModels.BotUsingSpaces.TwitchModels
{
    public class TwitchInstanses
    {
        public int userID { get; set; }
        public string ChannelName { get; set; }
        public string Token { get; set; }
        public string SturtupMessage { get; set; }
    }
}