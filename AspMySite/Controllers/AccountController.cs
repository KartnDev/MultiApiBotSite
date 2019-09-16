using AspMySite.Models;
using AspMySite.Models.SQLModel.DbTableModels;
using AspMySite.Models.SQLModel.LoginModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspMySite.Controllers
{
    public class AccountController : Controller
    {
        // sing in = login
        // sing up = registration

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegistrationModel model)
        {
            SiteUser user = null;
            using (UserContext db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.login == model.Name);

            }
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(model.Name, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
            }
            return View();
        }

        // GET: Account
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationModel model)
        {
            SiteUser user = null;
            using (UserContext db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.login == model.Name);

            }
            if (user == null)
            {
                using (UserContext db = new UserContext())
                {
                    db.Users.Add(new SiteUser { login = model.Name, password = model.Password, Age = model.Age, SiteAdmin = false });
                    db.SaveChanges();


                    user = db.Users.Where(u => u.login == model.Name && u.password == model.Password).FirstOrDefault();
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Username occupied!");
            }
            return View();
        }


    }
}