using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mini_project.Controllers
{
    public class MarketController : Controller
    {
        // GET: Market
        public ActionResult user()
        {
            return View();
        }

        public ActionResult admin()
        {
            return View();
        }


       
        [HttpPost]
        public ActionResult admin(FormCollection form)
        {
            var imageUrl = form["ImageUrl"];
            var name = form["Name"];
            var price = form["Price"];

            var itemList = Session["ItemList"] as List<string[]> ?? new List<string[]>();

            itemList.Add(new[] 
            { imageUrl
            , name, 
              price });

            Session["ItemList"] = itemList;

            return View("user");
        }


    }
}