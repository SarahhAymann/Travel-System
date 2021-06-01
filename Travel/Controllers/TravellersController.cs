using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class TravellersController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Travellers
        public ActionResult Index()
        {
            return View(db.traveller.ToList());
        }

        // GET: Travellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveller traveller = db.traveller.Find(id);
            if (traveller == null)
            {
                return HttpNotFound();
            }
            return View(traveller);
        }

        // GET: Travellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Travellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirtsName,LastName,UserName,PhoneNumber,Email,Password,ConfrimPassword")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                db.traveller.Add(traveller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traveller);
        }

        // GET: Travellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveller traveller = db.traveller.Find(id);
            if (traveller == null)
            {
                return HttpNotFound();
            }
            return View(traveller);
        }

        // POST: Travellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirtsName,LastName,UserName,PhoneNumber,Email,Password,ConfrimPassword")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traveller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traveller);
        }

        // GET: Travellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveller traveller = db.traveller.Find(id);
            if (traveller == null)
            {
                return HttpNotFound();
            }
            return View(traveller);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traveller traveller = db.traveller.Find(id);
            db.traveller.Remove(traveller);
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
