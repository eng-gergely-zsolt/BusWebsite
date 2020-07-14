using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusApplication.Models;

namespace BusApplication.Controllers
{
    public class BusesController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: Buses
        public ActionResult Index()
        {
            return View(db.Buses.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus buses = db.Buses.Find(id);
            if (buses == null)
            {
                return HttpNotFound();
            }
            return View(buses);
        }

        // GET: Buses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusId,BusName")] Bus buses)
        {
            if (ModelState.IsValid)
            {
                db.Buses.Add(buses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buses);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus buses = db.Buses.Find(id);
            if (buses == null)
            {
                return HttpNotFound();
            }
            return View(buses);
        }

        // POST: Buses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusId,BusName")] Buses buses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buses);
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus buses = db.Buses.Find(id);
            if (buses == null)
            {
                return HttpNotFound();
            }
            return View(buses);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bus buses = db.Buses.Find(id);
            db.Buses.Remove(buses);
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
