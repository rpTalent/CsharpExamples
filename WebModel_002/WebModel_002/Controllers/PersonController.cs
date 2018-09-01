using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebModel_002.Models;

namespace WebModel_002.Controllers
{
    public class PersonController : Controller
    {
        private const string KEY = "PROVIDER";

        private PersonProvider Provider { get { return getProvider(); } }

        [Authorize]
        public ActionResult PersonList()
        {
            return View(Provider);
        }

        //Akcja InsertOrUpdate, poprzez wywoalnie POST zapisuje lub dodaje do listy i przekierowuje do akcji Insert, wyswietlajacej liste 
        [HttpPost]
        [Authorize]
        public ActionResult InsertOrUpdate(Person value)
        {
            if (!ModelState.IsValid)
                return View(value);
            Provider.InsertOrUpdate(value);
            return RedirectToAction("PersonList");
        }

        //Akcja Insert, porzez domyslne wywolanie GET prezkierowuje do widoku InsertOrUpdate, wyswietlajacego jedynie formularz 
        [Authorize]
        public ActionResult Insert()
        {
            return View("InsertOrUpdate");
        }

        //Akcja Update, porzez domyslne wywolanie GET prezkierowuje do widoku InsertOrUpdate, do widoku dostarcza obiekt Person
        [Authorize]
        public ActionResult Update(string id)
        {
            return View("InsertOrUpdate", Provider.Find(id));
        }

        [Authorize]
        public ActionResult Delete(string id)
        {
            Provider.Remove(id);
            return RedirectToAction("PersonList");
        }

        private PersonProvider getProvider()
        {
            if (Session[KEY] == null)
                Session[KEY] = new PersonProvider();
            return (PersonProvider)Session[KEY];
        }

    }
}