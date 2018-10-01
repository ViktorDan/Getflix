﻿using System;
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
        public ActionResult Index(Kunde innLogget)
        {
            // sjekk om login var OK
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
        public ActionResult Registrer(Kunde innKunde)
        {
            // åpner først databasen ved å instansiere et DB objekt.
            using (var db = new DBContext())
            {
                try
                {
                    // lag kunde med passord salt+hash, add kunde til tabellen Kunder, og commit ved "savechanges".
                    var nyKunde = new dbKunder();
                    string salt = DBFunk.lagSalt();
                    var passordOgSalt = innKunde.Passord + salt;
                    byte[] passordDb = DBFunk.lagHash(passordOgSalt);
                    nyKunde.Navn = innKunde.Navn;
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
            return View();
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