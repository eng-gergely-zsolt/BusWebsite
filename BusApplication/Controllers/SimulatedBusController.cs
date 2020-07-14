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
    public class SimulatedBusController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: SimulatedBus
        public ActionResult Index()
        {
            var simulatedBus = db.SimulatedBus.Include(s => s.Bus);
            return View(simulatedBus.ToList());
        }

        // GET: SimulatedBus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimulatedBu simulatedBus = db.SimulatedBus.Find(id);
            if (simulatedBus == null)
            {
                return HttpNotFound();
            }
            return View(simulatedBus);
        }

        // GET: SimulatedBus/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            return View();
        }

        // POST: SimulatedBus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastCheckin,Measurement_Timestamp,BusId")] SimulatedBu simulatedBus)
        {
            if (ModelState.IsValid)
            {
                db.SimulatedBus.Add(simulatedBus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", simulatedBus.BusId);
            return View(simulatedBus);
        }

        // GET: SimulatedBus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimulatedBu simulatedBus = db.SimulatedBus.Find(id);
            if (simulatedBus == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", simulatedBus.BusId);
            return View(simulatedBus);
        }

        // POST: SimulatedBus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastCheckin,Measurement_Timestamp,BusId")] SimulatedBus simulatedBus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(simulatedBus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", simulatedBus.BusId);
            return View(simulatedBus);
        }

        // GET: SimulatedBus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SimulatedBu simulatedBus = db.SimulatedBus.Find(id);
            if (simulatedBus == null)
            {
                return HttpNotFound();
            }
            return View(simulatedBus);
        }

        // POST: SimulatedBus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SimulatedBu simulatedBus = db.SimulatedBus.Find(id);
            db.SimulatedBus.Remove(simulatedBus);
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
