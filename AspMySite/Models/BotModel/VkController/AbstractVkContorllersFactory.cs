using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.BotModel.VkController
{
    public abstract class AbstractVkContorllersFactory
    {
        public abstract AbstractVkEventController CreateController(string token);
    }
}