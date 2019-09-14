using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMySite.Controllers
{
    public class BotManagmentController : Controller
    {
        // GET: BotManagment
        public ActionResult BotManagementIndex()
        {
            ViewBag.BotStatus = "Bot is offline";


            return View();
        }

        public ActionResult BotSettings()
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