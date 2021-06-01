using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class homeController : Controller
    {
        MyDbContext MyDb = new MyDbContext();
        // GET: home
        string Admin = "Admin";
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


             
                var data = MyDb.users.Where(s => s.UserName.Equals(username) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                
                    Session["UserName"] = data.FirstOrDefault().UserName;
                    Session["UserRole"] = data.FirstOrDefault().UserRole;
                    int convertKey = Convert.ToInt32(Session["UserRole"]);


                    if (convertKey == 1)
                    {
                        return RedirectToAction("AdminIndex", "Admin");

                    }
                    else
                    {
                        return RedirectToAction("Index");

                    }
                    

                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

    }
}
