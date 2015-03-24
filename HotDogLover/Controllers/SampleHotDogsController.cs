using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotDogLover.DAL;

namespace HotDogLover.Controllers
{
    public class SampleHotDogsController : Controller
    {
        private hotdogEntities db = new hotdogEntities();

        // GET: SampleHotDogs
        public ActionResult Index()
        {
            return View(db.HotDogs.ToList());
        }

        // GET: SampleHotDogs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDog hotDog = db.HotDogs.Find(id);
            if (hotDog == null)
            {
                return HttpNotFound();
            }
            return View(hotDog);
        }

        // GET: SampleHotDogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleHotDogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HotDogID,Name,LastAte,LastPlaceAte")] HotDog hotDog)
        {
            if (ModelState.IsValid)
            {
                db.HotDogs.Add(hotDog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotDog);
        }

        // GET: SampleHotDogs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDog hotDog = db.HotDogs.Find(id);
            if (hotDog == null)
            {
                return HttpNotFound();
            }
            return View(hotDog);
        }

        // POST: SampleHotDogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HotDogID,Name,LastAte,LastPlaceAte")] HotDog hotDog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotDog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotDog);
        }

        // GET: SampleHotDogs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotDog hotDog = db.HotDogs.Find(id);
            if (hotDog == null)
            {
                return HttpNotFound();
            }
            return View(hotDog);
        }

        // POST: SampleHotDogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            HotDog hotDog = db.HotDogs.Find(id);
            db.HotDogs.Remove(hotDog);
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
