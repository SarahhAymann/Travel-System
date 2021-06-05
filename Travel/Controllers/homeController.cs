using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index()
        {
            return View();
        }
        //GET: Register

        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserInfo _user)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(_user.ImageFile.FileName);
                string extension = Path.GetExtension(_user.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                _user.Image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                _user.ImageFile.SaveAs(fileName);


                var check = MyDb.users.FirstOrDefault(s => s.UserName == _user.UserName || s.Email == _user.Email);
                if (check == null)
                {
                    _user.Password = _user.Password;


                    MyDb.Configuration.ValidateOnSaveEnabled = false;
                    MyDb.users.Add(_user);
                    MyDb.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
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
                    Session["UseId"] = data.FirstOrDefault().ID;
                    Session["UserRole"] = data.FirstOrDefault().UserRole;
                    Session["FirstName"] = data.FirstOrDefault().FirtsName;
                    Session["LastName"] = data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["Phone"] = data.FirstOrDefault().PhoneNumber;
                    Session["UserRole"] = data.FirstOrDefault().UserRole;
                    Session["UserImage"] = data.FirstOrDefault().Image;
                 

                    if (Session["UserRole"].ToString() == "admin")

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
