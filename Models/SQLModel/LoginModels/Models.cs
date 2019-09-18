using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMySite.Models.SQLModel.LoginModels
{
    public class LoginModel
    {
        public string Name { get; set; }
        public string Password { get; set; }

    }

    public class RegistrationModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Age { get; set; }
    }


}