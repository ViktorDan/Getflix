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
        // Verifiserer login fra bruker og sender bruker til hovedside hvis OK. Oppretter også Session som lagrer Brukernavnet.
        public ActionResult Index(Kunde innLogget)
        {
            if (DBFunk.bruker_i_db(innLogget))
            {
                Session["LoggetInn"] = true;
                Session["Brukernavn"] = innLogget.Brukernavn;
                Session["FeilMelding"] = "";
                return RedirectToAction("HovedSide");
            }
            else
            {
                Session["LoggetInn"] = false;
                Session["FeilMelding"] = "Feil brukernavn og passord";
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
            if (SjekkLogin())
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
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult NyHovedSide()
        {
            if (SjekkLogin())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // Ender Session.
        public ActionResult LoggUt()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        // Funksjoner
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
        // Funksjon som legger inn kjøp av film i databasen
        public void Bestilling(int id)
        {
            using (var db = new DBContext())
            {
                var brukernavn = (string)Session["Brukernavn"];

                var bestilling = new Bestillinger
                {

                    Brukernavn = brukernavn,
                    FId = id
                };

                db.Bestillinger.Add(bestilling);
                db.SaveChanges();
            }
        }

        //Funksjon som laster in filmer i en sjanger ved hjelp av Ajax kall
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

                    innhold += "<td id='element' width='20%'><img src='" + f.Bilde + "' width='90%'> <br/>" + f.Navn +
                        "<br/><a href='" + Url.Action("NyHovedSide") + "?data=" + f.FId +
                        "' id='button' class='btn btn-success' value='" + f.FId + "'>Mer Info</a><br/><br/><td/>";
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

        //Funksjon som laster in alle filmer ved hjelp av Ajax kall
        public String AlleFilmer(String Sjanger)
        {
            using (var db = new Models.DBContext())
            {
                var filmer = db.Filmer.ToList();
                String innhold = "<table><tr>";
                var count = 0;
                foreach (var f in filmer)
                {
                    count++;

                    innhold += "<td id='element' width='20%'><img src='" + f.Bilde + "' width='90%'><br/>" + f.Navn +
                        "<br/><a href='" + Url.Action("NyHovedSide") + "?data=" + f.FId +
                        "' id='button' class='btn btn-success' value='" + f.FId + "'>Mer Info</a><br/><br/> <td/>";
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
        // Funksjon som laster inn informasjon om valgt film ved hjelp av Ajax
        public String HentFilmInfo(int id)
        {
            using (var db = new Models.DBContext())
            {

                var filmer = db.Filmer.Where(s => s.FId == id);
                String innhold = "<table><tr>";

                foreach (var f in filmer)
                {
                    innhold += "<td><img src='" + f.Bilde + "' width='90%'></td><td><h3>" + f.Navn + "</h3><br/>År " + f.Aar + "<br/" +
                        f.Sjanger + "<br/>" + f.Lengde + " Minutter<br/>" + f.Storrelse + " Gb<br/>" + f.Pris +
                        " Kr <br/><button id='kjop' class='btn btn-success' onclick='myAlert()'>Kjøp</button><td/>";
                }
                innhold += "<tr/><table/>";
                return innhold;
            }
        }

    }
}