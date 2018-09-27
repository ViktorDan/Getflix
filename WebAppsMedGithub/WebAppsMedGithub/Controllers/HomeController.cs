using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult KundeRegistrer()
        {
            return View();

        }

        public ActionResult HovedSide()
        {
            var db = new DBFunksjonalitet();
            List<Film> alleFilmer = db.alleFilmer();
            return View(alleFilmer);
        }

        public ActionResult FilmRegistrer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FilmRegistrer(Film innFilm)
        {
            var db = new DBFunksjonalitet();
            bool OK = db.lagreFilm(innFilm);
            if(OK)
            {
                return RedirectToAction("Liste");
            }
            return View();
        }
    }
}