using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task6_MVC.Models;

namespace Task6_MVC.Controllers
{
    public class AccountController : Controller
    {

        Task6_loginEntities db = new Task6_loginEntities();

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult regestration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult regestration([Bind(Include = "userID,userName,userEmail,userPassword,userImage, ConfirmPassword")] loginTask6 uSER, string confirmpassowrd)
        {
            if (ModelState.IsValid && uSER.userPassword == confirmpassowrd)
            {
                db.loginTask6.Add(uSER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uSER);
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(loginTask6 uSER)
        {
            var checkInputs = db.loginTask6.Where(model => model.userEmail == uSER.userEmail && model.userPassword == uSER.userPassword).FirstOrDefault();

            Session["UserID"] = checkInputs.userID;


            if (checkInputs != null)
            {
                return RedirectToAction("Index");
            }

            return View();
        }





        public ActionResult Logout()
        {
            Session["userID"] = null;
            return RedirectToAction("Index");
        }








        public ActionResult Profile()
        {
            var userID = (int)Session["UserID"];
            var user = db.loginTask6.Find(userID);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(loginTask6 uSER, HttpPostedFileBase upload)
        {


            if (upload != null && upload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(upload.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), fileName);

                if (!Directory.Exists(Server.MapPath("~/Images/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/"));
                }

                upload.SaveAs(path);
                uSER.userImg = fileName;
            }

            db.Entry(uSER).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}