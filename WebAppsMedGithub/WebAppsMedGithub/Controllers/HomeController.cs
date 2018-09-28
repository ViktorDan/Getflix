using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace WebAppsMedGithub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // sjekk login
            if(Session["LoggetInn"] == null)
            {
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
            }
            else
            {
                ViewBag.Innlogget = (bool)Session["LoggetInn"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Models.Kunde innLogget)
        {
            // sjekk om login var OK
            if (bruker_i_db(innLogget))
            {
                // brukernavn og passord OK
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
            }
            else
            {
                // brukernavn og passord ikke OK
                Session["LoggetInn"] = false;
                ViewBag.Innlogget = false;
                return View();
            }
        }

        public ActionResult Registrer()
        {
            return View();

        }

     

        [HttpPost]
        public ActionResult Registrer(Models.Kunde innKunde)
        {
            // åpner først databasen ved å instansiere et DB objekt.
            using (var db = new Models.DBContext())
            {
                try
                {
                    // add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new Models.dbKunder();
                    byte[] passordDb = lagHash(innKunde.Passord);
                    nyKunde.Fornavn = innKunde.Navn;
                    nyKunde.Passord = passordDb;
                    db.Kunder.Add(nyKunde);
                    db.SaveChanges();
                }
                catch (Exception feil)
                {
                    System.Diagnostics.Debug.WriteLine(feil);
                }
            }
            // db objektet dør ut etter at using metoden er ferdig. 
            return RedirectToAction("Index");
        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA512.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        private static string lagSalt()
        {
            byte[] randomArray = new byte[10];
            string randomString;
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomArray);
            randomString = Convert.ToBase64String(randomArray);
            return randomString;
        }

        public ActionResult HovedSide()
        {
            return View();
        }

        public ActionResult FilmRegistrer()
        {
            return View();
        }
    }
}