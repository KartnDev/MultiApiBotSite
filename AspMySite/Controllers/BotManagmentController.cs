using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMySite.Controllers
{

    [Authorize]
    public class BotManagmentController : Controller
    {
        // GET: BotManagment

        public ActionResult BotManagementIndex()
        {
            ViewBag.BotStatus = "Bot is offline";


            return View();
        }
        [HttpGet]
        public ActionResult BotVkSettings()
        {
            return View();
        }


        [HttpPost]
        public ActionResult BotVkSettings(vkInstanses VkForm)
        {
            return View();
        }

        public ActionResult EditUsers()
        {
            return View();
        }


        public ActionResult EditCommands()
        {
            return View();
        }
    }
}