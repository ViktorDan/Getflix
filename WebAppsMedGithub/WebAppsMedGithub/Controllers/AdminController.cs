using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppsMedGithub.Models;
using Model;
using BLL;
using System.IO;

namespace WebAppsMedGithub.Controllers
{
    public class AdminController : Controller
    {
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
                var adminDb = new AdminBLL();
                List<dbKunder> kunder = adminDb.HentAlleKunder();
                return View(kunder);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminFilm()
        {
            if (SjekkLogin())
            {
                var adminDb = new AdminBLL();
                List<Filmer> filmer = adminDb.HentAlleFilmer();
                return View(filmer);
            }
            else
                return RedirectToAction("Index", "Home");
        }
        public ActionResult AdminBestilling()
        {
            if (SjekkLogin())
            {
                var adminDb = new AdminBLL();
                List<Bestillinger> bestillinger = adminDb.HentAlleBestillinger();
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
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreKunde(id, bn, fn, en, ad, post, postSted, tlf);
        }
        public void SlettKunde(int id)
        {
            // denne kalles via et Ajax-kall
            var adminDb = new AdminBLL();
            bool slettOK = adminDb.SlettKunde(id);
            // kunne returnert en feil dersom slettingen feilet....
        }
        public ActionResult AdminRegistrerFilm()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegistrerFilm(Film innFilm)
        {
            Session["FeilMelding"] = "";
            DBFunk.RegistrerFilm(innFilm);
            return RedirectToAction("AdminFilm");
        }
        public void EndreFilm(int id, String tittel, int aar, String sjan, int len, int stor, int pris, String bilde)
        {
            var adminDb = new AdminBLL();
            bool endreOK = adminDb.EndreFilm(id, tittel, aar, sjan, len, stor, pris, bilde);
        }
        
        [HttpPost]
        public ActionResult Upload()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Bilder/"), fileName);
                    file.SaveAs(path);
                }
            }
            return RedirectToAction("AdminFilm", "Admin");
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