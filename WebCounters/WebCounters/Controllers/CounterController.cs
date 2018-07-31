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
            //Uzywamy obiektu ViewBag - property tego obiektu są tworzone automatycznie (np. ViewBag.SessionCounter)
            ViewBag.SessionCounter      = getSessionCounter().NextValue;
            ViewBag.StaticCounter       = getStaticCounter().NextValue;
            ViewBag.ApplicationCounter  = getApplicationCounter().NextValue;

            return View();
        }

        public ActionResult ShowCountersUsingModel()
        {
            return View(new CountersViewModel()
            {
                ApplicationCounter = getApplicationCounter(),
                SessionCounter = getSessionCounter(),
                StaticCounter = getStaticCounter()
            });
        }

        private BaseCounter getSessionCounter()
        {
            if (Session[KEY] == null)
                Session[KEY] = new NormalCounter();

            return (BaseCounter)Session[KEY];
        }

        private BaseCounter getApplicationCounter()
        {
            if (HttpContext.Application[KEY] == null)
                HttpContext.Application[KEY] = new NormalCounter();

            return (BaseCounter)HttpContext.Application[KEY];
        }

        private BaseCounter getStaticCounter()
        {
            return new StaticCounter();
        }
    }
}