using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using user_MVC.Models;

namespace user_MVC.Controllers
{
    public class USERController : Controller
    {
       

        private user_Entities1 db = new user_Entities1();

        // Here we can see the table
        public ActionResult Index()
        {
            return View(db.user28Jul.ToList());
        }

        public ActionResult Details(int id)
        {

            user28Jul data = db.user28Jul.Find(id);
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FullName,Email,Password,Image")] user28Jul data)
        {
            if (ModelState.IsValid)
            {
                db.user28Jul.Add(data);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {

            user28Jul data = db.user28Jul.Find(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,FullName,Email,Password,Image")] user28Jul data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public ActionResult Delete(int id)
        {

            user28Jul data = db.user28Jul.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            user28Jul data = db.user28Jul.Find(id);
            db.user28Jul.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
