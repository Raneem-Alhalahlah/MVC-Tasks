using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Task3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["logedIn"] = "false";
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

        public ActionResult SubmitContactForm(string name, string phoneNumber, string gender, string country, List<string> interests)
        {
            ViewBag.Name = name;
            ViewBag.PhoneNumber = phoneNumber;
            ViewBag.Gender = gender;
            ViewBag.Country = country;
            ViewBag.Interests = interests;

            return View("Contact");
        }


        [HttpPost]
        public ActionResult logIn(FormCollection form)
        {
            string email = form["email"];
            string password = form["password"];
            if (email == "ayah@gmail.com" && password == "123")
            {
                Session["logedIn"] = "true";
                return View("index");
            }
            return View("index");

        }
    }
}