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
    public class BusPositionsController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: BusPositions
        public ActionResult Index()
        {
            var busPositions = db.BusPositions.Include(b => b.Bus);
            return View(busPositions.ToList());
        }

        // GET: BusPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusPosition busPositions = db.BusPositions.Find(id);
            if (busPositions == null)
            {
                return HttpNotFound();
            }
            return View(busPositions);
        }

        // GET: BusPositions/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            return View();
        }

        // POST: BusPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Longitude,Latitude,Timestamp,BusId,Datapoints_nearby")] BusPosition busPositions)
        {
            if (ModelState.IsValid)
            {
                db.BusPositions.Add(busPositions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busPositions.BusId);
            return View(busPositions);
        }

        // GET: BusPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusPosition busPositions = db.BusPositions.Find(id);
            if (busPositions == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busPositions.BusId);
            return View(busPositions);
        }

        // POST: BusPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Longitude,Latitude,Timestamp,BusId,Datapoints_nearby")] BusPositions busPositions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busPositions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busPositions.BusId);
            return View(busPositions);
        }

        // GET: BusPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusPosition busPositions = db.BusPositions.Find(id);
            if (busPositions == null)
            {
                return HttpNotFound();
            }
            return View(busPositions);
        }

        // POST: BusPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusPosition busPositions = db.BusPositions.Find(id);
            db.BusPositions.Remove(busPositions);
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
