using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public void SlettKunde(String id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
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