using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lesson18_4_finish.Models;

namespace lesson18_4_finish.Controllers
{
    public class HomeController : Controller
    {
        CompContext db = new CompContext();
        public ActionResult Index()
        {
            return View(db.Computers);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}