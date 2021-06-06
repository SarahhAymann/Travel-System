using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class TripPostsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: TripPosts
        public ActionResult Index()
        {
            return View(db.tripPosts.ToList());
        }

        // GET: TripPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPosts tripPosts = db.tripPosts.Find(id);
            if (tripPosts == null)
            {
                return HttpNotFound();
            }
            return View(tripPosts);
        }

        // GET: TripPosts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TripPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TripTitle,TripDetails,PostDate,TripDate,TripDestination,TripImage")] TripPosts tripPosts)
        {
            if (ModelState.IsValid)
            {
                db.tripPosts.Add(tripPosts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tripPosts);
        }

        // GET: TripPosts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPosts tripPosts = db.tripPosts.Find(id);
            if (tripPosts == null)
            {
                return HttpNotFound();
            }
            return View(tripPosts);
        }

        // POST: TripPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TripTitle,TripDetails,PostDate,TripDate,TripDestination,TripImage")] TripPosts tripPosts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tripPosts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tripPosts);
        }

        // GET: TripPosts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPosts tripPosts = db.tripPosts.Find(id);
            if (tripPosts == null)
            {
                return HttpNotFound();
            }
            return View(tripPosts);
        }

        // POST: TripPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TripPosts tripPosts = db.tripPosts.Find(id);
            db.tripPosts.Remove(tripPosts);
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
