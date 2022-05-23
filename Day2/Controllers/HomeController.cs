using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HandsOnLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            if (id == null)
            {
                return Content("<h1>This is a demo of ContentResult </ h1 > ");
 }
            else if (id.ToLower() == "plain")
            {
                return Content("<h1>This is a demo of Content Result </ h1 > ", "text / plain");

            }
            else if (id.ToLower() == "html")
            {
                return Content("<h1>This is a demo of ContentResult </ h1 > ", "text / html");

            }
            else if (id.ToLower() == "xml")
            {
                return Content("<h1>This is a demo of ContentResult </ h1 > ", "text / xml");

            }
            return Content("Invalid content type");
            return View();
        }

        public ActionResult DownloadFile()
        {
            if (!System.IO.File.Exists(@"e:\lighthouse.jpg"))
            {
                return Content("File to be downloaded not found");
            }
            return File(@"e:\lighthouse.jpg", "image/jpg",
           "default.jpg");
        }
        public ActionResult Google()
        {
            return Redirect("http://www.google.com");
        }

        public ActionResult StartPage()
        {
            return RedirectToAction("Index", new { id = "xml" });
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
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