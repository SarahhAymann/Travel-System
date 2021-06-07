using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class AgencyController : Controller

    {


        private MyDbContext db = new MyDbContext();
        // GET: Agency
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ShowAgencyProfile()
        {
            return View();
        }

        
    


        // GET: TripPosts/Create
        public ActionResult CreateTripPostRequest()
        {
            return View();
        }

        // POST: TripPosts/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTripPostRequest( PostsRequests requests)
        {
            if (ModelState.IsValid)

            {
                requests.PostDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(requests.requestImageFile.FileName);
                string extension = Path.GetExtension(requests.requestImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                requests.TripImage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                requests.requestImageFile.SaveAs(fileName);

                db.postsRequests.Add(requests);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requests);
        }


        public ActionResult EditProfile(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserInfo user)
        {
            if (ModelState.IsValid)
            {
               
                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                user.Image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                user.ImageFile.SaveAs(fileName);

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewTraveller");
            }
            return View(user);
        }
    }


















    }