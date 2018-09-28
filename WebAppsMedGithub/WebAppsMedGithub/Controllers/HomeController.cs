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
            return View();
        }
    }
}