using AspMySite.Models;
using AspMySite.Models.SQLModel.DbTableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspMySite.Controllers
{
    [Authorize]
    public class BotSettingsController : Controller
    {
        // GET: BotSettings
        [HttpGet]
        public ActionResult VkSettings() => View();




        [HttpPost]
        public ActionResult VkSettiongs(vkInstanses postInstance)
        {
            vkInstanses vkInstanses = null;

            using(SiteContext db = new SiteContext())
            {
                // получить логин и пароль из куки и БД
                vkInstanses = db.uUserSiteInstances.FirstOrDefault(u => u.userSiteId == FormsAuthentication.GetAuthCookie());
            }
            if (vkInstanses != null)
            {
                // изменяем настройки

                using (SiteContext db = new SiteContext())
                {
                    db.uUserSiteInstances.FirstOrDefault(u => u.userSiteId == FormsAuthentication.GetAuthCookie("", true));
                }
            }
            else
            {
                // создаем и конфигурируем
                using (SiteContext db = new SiteContext())
                {
                    db.vkInstanses.Add(new vkInstanses()
                    {
                        dialogsHandlableList = postInstance.dialogsHandlableList,
                        Token = postInstance.Token,
                        InstanceID = db.uUserSiteInstances.Where(u => u.userSiteId == FormsAuthentication.GetAuthCookie("", true)).First().VkInstances
                    }); ; ;


                }
            }

            return View();
        }


    }
}