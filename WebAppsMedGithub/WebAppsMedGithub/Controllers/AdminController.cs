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

        private IAdminBLL _AdminBLL;

        public AdminController()
        {
            _AdminBLL = new AdminBLL();
        }

        public AdminController(IAdminBLL stub)
        {
            _AdminBLL = stub;
        }

        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AdminKunder()
        {
            List<dbKunder> kunder = _AdminBLL.HentAlleKunder();
            return View(kunder);
        }
        public ActionResult AdminFilm()
        {
            List<Filmer> filmer = _AdminBLL.HentAlleFilmer();
            return View(filmer);
        }
        public ActionResult AdminBestilling()
        {
            List<Bestillinger> bestillinger = _AdminBLL.HentAlleBestillinger();
            return View(bestillinger);
        }
        public void EndreKunde(int id, String bn, String fn, String en, String ad, int post, int tlf)
        {
            bool endreOK = _AdminBLL.EndreKunde(id, bn, fn, en, ad, post, tlf);
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