using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;



using System.Web.Security;


namespace Travel.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin


        MyDbContext MyDb = new MyDbContext();

        public ActionResult AdminIndex()
        {

            return View();
        }


        public ActionResult UsersPage()
        {

            return View();
        }

        public ActionResult ViewTraveller()
        {
            var traveller = GetTravellers();

            return View(traveller);
        }


        public IEnumerable<Traveller> GetTravellers()
        {

            var traveller = MyDb.traveller.ToList();




            return traveller;


        }

        public ActionResult EditTraveller(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveller traveller = MyDb.traveller.Find(id);
            if (traveller == null)
            {
                return HttpNotFound();
            }
            return View(traveller);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTraveller([Bind(Include = "ID,FirtsName,LastName,UserName,PhoneNumber,Email,Password,ConfrimPassword")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                MyDb.Entry(traveller).State = EntityState.Modified;
                MyDb.SaveChanges();
                return RedirectToAction("ViewTraveller");
            }
            return View(traveller);
        }

        public ActionResult CreateTraveller()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTraveller([Bind(Include = "ID,FirtsName,LastName,UserName,PhoneNumber,Email,Password,ConfrimPassword")] Traveller traveller)
        {
            if (ModelState.IsValid)
            {
                MyDb.traveller.Add(traveller);
                MyDb.SaveChanges();
                return RedirectToAction("ViewTraveller");
            }

            return View(traveller);
        }



        public ActionResult DeleteTraveller(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveller traveller = MyDb.traveller.Find(id);
            if (traveller == null)
            {
                return HttpNotFound();
            }
            return View(traveller);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("DeleteTraveller")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTravellerConfirmed(int id)
        {
            Traveller traveller = MyDb.traveller.Find(id);
            MyDb.traveller.Remove(traveller);
            MyDb.SaveChanges();
            return RedirectToAction("ViewTraveller");
        }

        public ActionResult ViewAgency()
        {
            var agency = GetAgencies();

            return View(agency);
        }


        public IEnumerable<Agencies> GetAgencies()
        {

            var agency = MyDb.agencies.ToList();




            return agency;

        }


        public ActionResult CreateAgency()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAgency([Bind(Include = "ID,FirtsName,LastName,UserName,PhoneNumber,Email,Password,ConfrimPassword")] Agencies agency)
        {
            if (ModelState.IsValid)
            {
                MyDb.agencies.Add(agency);
                MyDb.SaveChanges();
                return RedirectToAction("ViewAgency");
            }

            return View(agency);
        }



        public ActionResult DeleteAgency(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencies agency = MyDb.agencies.Find(id);
            if (agency == null)
            {
                return HttpNotFound();
            }
            return View(agency);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("DeleteAgency")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAgencyConfirmed(int id)
        {
            Agencies agency = MyDb.agencies.Find(id);
            MyDb.agencies.Remove(agency);
            MyDb.SaveChanges();
            return RedirectToAction("ViewAgency");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MyDb.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ShowProfile()
        {

            return View();

        }

        public ActionResult Requests()
        {
            var request = GetPostsRequests();

            return View(request);
        }


        public IEnumerable<PostsRequests> GetPostsRequests()
        {

            var requets = MyDb.postsRequests.ToList();




            return requets;


        }
        public ActionResult Approve(int? id)
        {
        
            PostsRequests requests = MyDb.postsRequests.ToList().Find(u => u.ID == id);
            requests.RequestStatus = "Approved";
            MyDb.SaveChanges();

           
            return RedirectToAction("Requests");
        }


        public ActionResult Disapprove(int id)
        {
            
            PostsRequests requests = MyDb.postsRequests.ToList().Find(u=> u.ID==id);
            requests.RequestStatus = "Disapproved";
            MyDb.SaveChanges();

            if (requests == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Requests");
        }

    }
}






