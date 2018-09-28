using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppsMedGithub.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrer()
        {
            return View();

        }

        private static byte[] lagHash(string innPassord)
        {
            byte[] innData, utData;
            var algoritme = System.Security.Cryptography.SHA512.Create();
            innData = System.Text.Encoding.ASCII.GetBytes(innPassord);
            utData = algoritme.ComputeHash(innData);
            return utData;
        }

        [HttpPost]
        public ActionResult Registrer(Models.Kunder innKunde)
        {
            // åpner først databasen ved å instansiere et DB objekt.
            using (var db = new Models.DBContext())
            {
                try
                {
                    // add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new Models.Kunder();
                    byte[] passordDb = lagHash(innKunde.Passord);
                    nyKunde.Fornavn = innKunde.Fornavn;
                    nyKunde.Passord = passordDb;

                    db.Kunder.Add(innKunde);
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