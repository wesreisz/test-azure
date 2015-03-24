using HotDogLover.Models;
using HotDogLover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotDogLover.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService profileService = new ProfileService();

        // GET: Profile
        public ActionResult Index()
        {
            return View(profileService.ListAll());
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            HotDogLover.Models.Profile profile = profileService.Get(id);
            return View(profile);
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View(profileService.Get(id));
        }

        // POST: Profile/Edit/5
        [HttpPost]
        //public ActionResult Create([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        public ActionResult Edit([Bind(Include="ProfileID, Name,Bio,Picture")]Profile profile)
        {
            if (!ModelState.IsValid) {
                return RedirectToAction("Edit", new {id=profile.ProfileID }); 
            }
            try
            {
                profileService.Update(profile);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Edit", new { id = profile.ProfileID }); 
            }
        }

        // GET: Profile/AddDog/5
        public ActionResult CreateDog(int id)
        {
            ViewBag.profileID = id;
            return View();
        }

        // POST: Profile/EditDog/5
        [HttpPost]
        //public ActionResult Create([Bind(Include = "StudentID,Name,Email,Age,Address,City,Zip,State")] Student student)
        public ActionResult AddDog(int profileID, [Bind(Include = "HotDogName,LastTimeAte,LastPlaceAte,Rating")]HotDog dog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.error = "Please check your form and resubmit";
                return RedirectToAction("CreateDog", new { id = profileID });
            }
            try
            {
                profileService.AddDog(new Profile() { ProfileID = profileID }, dog);
                return RedirectToAction("Details", new { id = profileID });
            }
            catch (Exception e){
                ViewBag.error = "Please check your form and resubmit";
                return RedirectToAction("CreateDog", new { id = profileID });
            }
        }
    }
}
