using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCounters.Models;

namespace WebCounters.Controllers
{
    public class CounterController : Controller
    {

        private const string KEY = "COUNTER";

        public ActionResult ShowCountersUsingViewBag()
        {

            ViewBag.SessionCounter = getSessionCounter().NextValue;
            ViewBag.StaticCounter = getStaticCounter().NextValue;

            return View();
        }

        private BaseCounter getSessionCounter()
        {
            if (Session[KEY] == null)
                Session[KEY] = new NormalCounter();

            return (BaseCounter)Session[KEY];
        }

        private BaseCounter getStaticCounter()
        {
            return new StaticCounter();
        }
    }
}