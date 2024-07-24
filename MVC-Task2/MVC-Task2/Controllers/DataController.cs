using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task2.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult ContactForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitContactForm(string name, string phoneNumber, string gender, string country, List<string> interests)
        {
            ViewBag.Name = name;
            ViewBag.PhoneNumber = phoneNumber;
            ViewBag.Gender = gender;
            ViewBag.Country = country;
            ViewBag.Interests = interests;

            return View("ShowContactInformation");
        }

        public ActionResult ShowContactInformation()
        {
            return View();
        }
    }
}