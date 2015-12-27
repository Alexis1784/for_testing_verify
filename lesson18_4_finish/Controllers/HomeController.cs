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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Computer c)
        {
            if (ModelState.IsValid)
            {
                repo.Create(c);
                repo.Save();
                return RedirectToAction("Index"); 
            }
            return View("Create");
        }

        IRepository repo;

        public HomeController(IRepository r)
        {
            repo = r;
        }
        public HomeController()
        {
            repo = new ComputerRepository();
        }

        public ActionResult Index()
        {
            var model = repo.GetComputerList();
            if (model.Count > 0)
                ViewBag.Message = String.Format("В базе данных {0} объект", model.Count);
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
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