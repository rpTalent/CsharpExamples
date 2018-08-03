using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModel_001.Models;

namespace WebModel_001.Controllers
{
    public class HomeController : Controller
    {

        private const string KEY = "PROVIDER";

        public PersonProvider Provider { get { return getProvider();} }

        public ActionResult Index()
        {
            return View(Provider);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private PersonProvider getProvider()
        {
            if (Session[KEY] == null)
                Session[KEY] = new PersonProvider();
            return (PersonProvider)Session[KEY];
        }


    }
}