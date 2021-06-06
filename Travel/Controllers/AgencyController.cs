using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        // GET: TripPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripPosts/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( PostsRequests requests)
        {
            if (ModelState.IsValid)

            {
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
    }
}