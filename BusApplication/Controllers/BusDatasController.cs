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
    public class BusDatasController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: BusDatas
        public ActionResult Index()
        {
            var busData = db.BusDatas.Include(b => b.Bus);
            return View(busData.ToList());
        }

        // GET: BusDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusData busData = db.BusDatas.Find(id);
            if (busData == null)
            {
                return HttpNotFound();
            }
            return View(busData);
        }

        // GET: BusDatas/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            return View();
        }

        // POST: BusDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Actual_Longitude,Actual_Latitude,Measurement_Timestamp,Actual_Speed,BusId")] BusData busData)
        {
            if (ModelState.IsValid)
            {
                db.BusDatas.Add(busData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busData.BusId);
            return View(busData);
        }

        // GET: BusDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusData busData = db.BusDatas.Find(id);
            if (busData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busData.BusId);
            return View(busData);
        }

        // POST: BusDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Actual_Longitude,Actual_Latitude,Measurement_Timestamp,Actual_Speed,BusId")] BusData busData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busData.BusId);
            return View(busData);
        }

        // GET: BusDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusData busData = db.BusDatas.Find(id);
            if (busData == null)
            {
                return HttpNotFound();
            }
            return View(busData);
        }

        // POST: BusDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusData busData = db.BusDatas.Find(id);
            db.BusDatas.Remove(busData);
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
