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

        //Akcja Insert, poprzez wywoalnie POST zapisuje do listy i przekierowuje do akcji Insert, wyswietlajacej liste 
        [HttpPost]
        public ActionResult Insert(Person value)
        {
            Provider.Insert(value, true);
            return RedirectToAction("Index");
        }

        //Akcja Insert, porzez domyslne wywolanie GET prezkierowuje do widoku Insert, wyswietlajacego jedynie formularz 
        public ActionResult Insert()
        {
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