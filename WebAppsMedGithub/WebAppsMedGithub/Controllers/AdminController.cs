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
            if (SjekkLogin())
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult AdminKunder()
        {
            if (SjekkLogin())
            {
                List<dbKunder> kunder = _AdminBLL.HentAlleKunder();
                return View(kunder);
            }
            else
                return RedirectToAction("Index", "Home");
            
        }

        public ActionResult AdminFilm()
        {
            if (SjekkLogin())
            {
                List<Filmer> filmer = _AdminBLL.HentAlleFilmer();
                return View(filmer);
            }
            else
                return RedirectToAction("Index", "Home");
        
            
        }

        public ActionResult AdminBestilling()
        {
            if (SjekkLogin())
            {
                List<Bestillinger> bestillinger = _AdminBLL.HentAlleBestillinger();
                return View(bestillinger);
            }
            else
                return RedirectToAction("Index", "Home");
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

        public void EndreKunde(int id, String bn, String fn, String en, String ad, String post, String postSted, int tlf)
        {     
            bool endreOK = _AdminBLL.EndreKunde(id, bn, fn, en, ad, post, postSted, tlf);
        }

        public void SlettKunde(int id)
        {
            // denne kalles via et Ajax-kall

            bool slettOK = _AdminBLL.SlettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
        }

        public void EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris)
        {
            bool endreOK = _AdminBLL.EndreFilm(id, tittel, aar, sjan, len, stor, pris);
        }
        public void SlettFilm(int id)
        {
            // denne kalles via et Ajax-kall
            bool slettOK = _AdminBLL.SlettFilm(id);
            // kunne returnert en feil dersom slettingen feilet....
        }

        public void SlettBestilling(int id)
        {
            // denne kalles via et Ajax-kall
            bool slettOK = _AdminBLL.SlettBestilling(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        // Ender Session.
        public ActionResult LoggUt()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public bool SjekkLogin()
        {
            if (Session["AdminLoggetInn"] != null)
            {
                bool loggetInn = (bool)Session["AdminLoggetInn"];
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