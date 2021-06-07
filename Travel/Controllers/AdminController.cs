using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;



using System.Web.Security;
using System.IO;

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


        public ActionResult ViewUsers()
        {

            var Users = GetUsers();

            return View(Users);

        }





        public IEnumerable<UserInfo> GetUsers()
        {
            var user = MyDb.users.ToList();

            foreach (var item in user)
            {
                if(item.UserRole == "admin")
                {
                    
                    user.Remove(item);

                    return user;

                }
            }


            return Enumerable.Empty<UserInfo>();
            
      


        }






        public ActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(user.ImageFile.FileName);
                string extension = Path.GetExtension(user.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                user.Image = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                user.ImageFile.SaveAs(fileName);

                MyDb.users.Add(user);
                MyDb.SaveChanges();
                return RedirectToAction("ViewUsers");
            }

            return View(user);
        }





        public ActionResult DeleteUsers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo user = MyDb.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("DeleteUsers")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUsersConfirm(int id)
        {
            UserInfo user = MyDb.users.Find(id);
            MyDb.users.Remove(user);
            MyDb.SaveChanges();
            return RedirectToAction("ViewUsers");
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                MyDb.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult ViewTripPosts()
        {
            var TripPost = GetTripPosts();

            return View(TripPost);
        }


        public IEnumerable<TripPosts> GetTripPosts()
        {

            var TripPost = MyDb.tripPosts.ToList();




            return TripPost;


        }

        public ActionResult CreateTripPost()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTripPost(TripPosts post)
        {
            if (ModelState.IsValid)

            {
                post.PostDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(post.postImageFile.FileName);
                string extension = Path.GetExtension(post.postImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                post.TripImage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                post.postImageFile.SaveAs(fileName);

                MyDb.tripPosts.Add(post);
                MyDb.SaveChanges();
                return RedirectToAction("ViewTripPosts");
            }

            return View(post);
        }




        public ActionResult EditTripPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPosts post = MyDb.tripPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTripPost(TripPosts post)
        {
            if (ModelState.IsValid)
            {
                post.PostDate = DateTime.Now;
                post.TripDate = DateTime.Now;
                string fileName = Path.GetFileNameWithoutExtension(post.postImageFile.FileName);
                string extension = Path.GetExtension(post.postImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                post.TripImage = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                post.postImageFile.SaveAs(fileName);

                MyDb.Entry(post).State = EntityState.Modified;
                MyDb.SaveChanges();
                return RedirectToAction("ViewTraveller");
            }
            return View(post);
        }


        public ActionResult DeleteTripPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TripPosts post = MyDb.tripPosts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Travellers/Delete/5
        [HttpPost, ActionName("DeleteTripPost")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTripPostConfirmed(int id)
        {
            TripPosts post = MyDb.tripPosts.Find(id);
            MyDb.tripPosts.Remove(post);
            MyDb.SaveChanges();
            return RedirectToAction("ViewTripPosts");
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
            TripPosts posts = new TripPosts();
            MyDb.SaveChanges();
            posts.TripTitle = requests.TripTitle;
            posts.TripDetails = requests.TripDetails;
            posts.TripDate = requests.TripDate;
            posts.PostDate = requests.PostDate;
            posts.TripDestination = requests.TripDestination;
            posts.TripImage = requests.TripImage;
            MyDb.tripPosts.Add(posts);


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







