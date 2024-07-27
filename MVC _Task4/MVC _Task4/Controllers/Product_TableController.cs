using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC__Task4.Models;

namespace MVC__Task4.Controllers
{
    public class Product_TableController : Controller
    {
        private Task_ProductEntities1 db = new Task_ProductEntities1();

        // GET: Product_Table
        public ActionResult Index()
        {
            return View(db.Product_Table.ToList());
        }

        // GET: Product_Table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            return View(product_Table);
        }

        // GET: Product_Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name_of_Product,Description,Price")] Product_Table product_Table)
        {
            if (ModelState.IsValid)
            {
                db.Product_Table.Add(product_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Table);
        }

        // GET: Product_Table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            return View(product_Table);
        }

        // POST: Product_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name_of_Product,Description,Price")] Product_Table product_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Table);
        }

        // GET: Product_Table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Table product_Table = db.Product_Table.Find(id);
            if (product_Table == null)
            {
                return HttpNotFound();
            }
            return View(product_Table);
        }

        // POST: Product_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_Table product_Table = db.Product_Table.Find(id);
            db.Product_Table.Remove(product_Table);
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
