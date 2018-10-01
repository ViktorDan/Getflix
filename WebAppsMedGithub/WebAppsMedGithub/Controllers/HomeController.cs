using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsMedGithub.Models;

namespace WebAppsMedGithub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult KundeRegistrer()
        {
            return View();

        }

        // legger kunde inn i database hvis valideringen er OK, funker ikke enda
        /*
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult KundeRegistrer(Kunde innKunde)
        {
            if(ModelState.IsValid)
            {
                var kundeDb = new DBkunde();
                Kunde enKunde = KundeDb.settInn(innKunde);
                if(insertOK)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(); 
        }*/

        public ActionResult HovedSide()
        {
            return View();
        }
    }
}