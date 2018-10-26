using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsMedGithub.Models;
using Model;
using BLL;

namespace WebAppsMedGithub.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AdminKunder()
        {
            var adminDb = new AdminBLL();
            List<dbKunder> kunder = adminDb.HentAlleKunder();
            return View(kunder);
        }
        public ActionResult AdminFilm()
        {
            var adminDb = new AdminBLL();
            List<Filmer> filmer = adminDb.HentAlleFilmer();
            return View(filmer);
        }
        public ActionResult AdminBestilling()
        {
            var adminDb = new AdminBLL();
            List<Bestillinger> bestillinger = adminDb.HentAlleBestillinger();
            return View(bestillinger);
        }
        public ActionResult AdminRegistrerKunde()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegistrerKunde(Kunde innKunde)
        {
            Session["FeilMelding"] = "";
            DBFunk.RegistrerKunde(innKunde);
            return RedirectToAction("AdminKunder");
        }
        public void EndreKunde(int id, String bn, String fn, String en, String ad, String post, int tlf)
        {
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreKunde(id, bn, fn, en, ad, post, tlf);
        }
        public void SlettKunde(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        public void EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris)
        {
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreFilm(id, tittel, aar, sjan, len, stor, pris);
        }
        public void SlettFilm(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettFilm(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        public void SlettBestilling(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettBestilling(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
     
        
        //public bool SjekkLogin()
        //{
        //    if (Session["LoggetInn"] != null)
        //    {
        //        bool loggetInn = (bool)Session["LoggetInn"];
        //        if (loggetInn)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        // Ender Session.
        public ActionResult LoggUt()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}