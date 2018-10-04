using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Verifiserer login fra bruker og sender bruker til hovedside hvis OK.
        public ActionResult Index(Kunde innLogget)
        {
            if (DBFunk.bruker_i_db(innLogget))
            {
                Session["LoggetInn"] = true;
                return RedirectToAction("HovedSide");
            }
            else
            {
                Session["LoggetInn"] = false;
                return View();
            }
        }

        public ActionResult Registrer()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrer(Kunde innKunde)
        {
            DBFunk.RegistrerKunde(innKunde);
            return RedirectToAction("Index");
        }        

        public ActionResult HovedSide()
        {
            //if (SjekkLogin())
            //{
                using (var db = new Models.DBContext())
                {
                    var filmer = db.Filmer.ToList();
                    var nedTrekk = new List<string>();
                    nedTrekk.Add("Velg Sjanger");
                    nedTrekk.Add("Alle Filmer");
                    foreach (var b in filmer)
                    {
                        if (!nedTrekk.Contains(b.Sjanger))
                            nedTrekk.Add(b.Sjanger);
                    }
                    return View(nedTrekk);
                }
            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}
        }

        public String HentFilm(String Sjanger)
        {
            using (var db = new Models.DBContext())
            {

                var filmer = db.Filmer.Where(s => s.Sjanger == Sjanger);
                String innhold = "<table><tr>";
                var count = 0;
                foreach (var f in filmer)
                {
                    count++;

                    innhold += "<td id='element' width='20%'><img src='" + f.Bilde + "' width='90%'> <br/>" + f.Navn + "<td/>";
                    if (count == 5)
                    {
                        innhold += "<tr/><tr>";
                        count = 0;
                    }
                }
                innhold += "<tr/><table/>";
                return innhold;
            }
        }
        public String AlleFilmer(String Sjanger)
        {
            using (var db = new Models.DBContext())
            {
                var filmer = db.Filmer;
                String innhold = "<table><tr>";
                var count = 0;
                foreach (var f in filmer)
                {
                    count++;

                    innhold += "<td id='element' width='20%'><img src='" + f.Bilde + "' width='90%'> <br/>" + f.Navn + "<td/>";
                    if(count == 5)
                    {
                        innhold += "<tr/><tr>";
                        count = 0;
                    }
                }
                innhold += "<tr/><table/>";
                return innhold;
            }
        }

        // Side som kun sjekker om du er logget inn.
        public ActionResult InnLogget()
        {
            if (SjekkLogin())
            {
                return View();
            }
            return RedirectToAction("Index");
        }

        // Ender Session.
        public ActionResult LoggUt()
        {
            Session["LoggetInn"] = null;
            return RedirectToAction("Index");
        }

        // Må legge metoder et annet sted enn her.
        public bool SjekkLogin()
        {
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}