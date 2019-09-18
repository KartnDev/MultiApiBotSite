using AspMySite.Models.BotModel.BotActioner.VkMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AspMySite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(!User.Identity.IsAuthenticated)
            {
               
            }
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //VkMethods methods = new VkMethods("e3c30bf8a99dd17da33d10b5087627fd5b23ce60cb6e894d4598d8265b4ea7310b85ed6fabb5da3019b37");
            //methods.Kick(257606382, 3);
            //methods.Invite(257606382, 3);
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}