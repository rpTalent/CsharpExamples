using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebModel_002.Models;
using System.Security.Principal;

namespace WebModel_002.Controllers
{
    public class LoginController : Controller
    {
        private const string VALID_USER = "admin";
        private const string VALID_PASS = "admin";

        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AuthData value)
        {
            if ((value.UserName == VALID_USER) && (value.UserPass == VALID_PASS))
            {
                FormsAuthentication.SetAuthCookie(value.UserName, false);
                return RedirectToAction("PersonList", "Person");
            }

            else
                return View("LoginForm", value); 
        }       

    }
}