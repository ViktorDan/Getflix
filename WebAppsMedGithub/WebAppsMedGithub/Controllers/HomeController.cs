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
            // Sjekker om det er en aktiv login når man går inn i Index
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
        public ActionResult Index(Kunde innLogget)
        {
            // Sjekker om login var OK
            if (DBFunk.bruker_i_db(innLogget))
            {
                // brukernavn og passord OK
                Session["LoggetInn"] = true;
                ViewBag.Innlogget = true;
                return View();
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
        [ValidateAntiForgeryToken]
        public ActionResult Registrer(Kunde innKunde)
        {
            // åpner først databasen ved å instansiere et DB objekt.
            using (var db = new DBContext())
            {
                try
                {
                    // lag kunde med passord salt+hash, add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new dbKunder();
                    nyKunde.Brukernavn = innKunde.Brukernavn;
                    nyKunde.Fornavn = innKunde.Fornavn;
                    nyKunde.Etternavn = innKunde.Etternavn;
                    nyKunde.Adresse = innKunde.Adresse;
                    nyKunde.Postnr = innKunde.Postnr;
                    nyKunde.Tlf = innKunde.Tlf;
                    string salt = DBFunk.lagSalt();
                    var passordOgSalt = innKunde.Passord + salt;
                    byte[] passordDb = DBFunk.lagHash(passordOgSalt);
                    nyKunde.Passord = passordDb;
                    nyKunde.Salt = salt;
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

        public ActionResult HovedSide()
        {
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
            if (Session["LoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["LoggetInn"];
                if (loggetInn)
                {
                    return View();
                }
            }
            return RedirectToAction("Index");
        }
    }
}