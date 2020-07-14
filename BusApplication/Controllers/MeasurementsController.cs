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
    public class MeasurementsController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: Measurements
        public ActionResult Index()
        {
            return View(db.Measurements.ToList());
        }

        // GET: Measurements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurements = db.Measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // GET: Measurements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Measurements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BusId,Longitude,Latitude,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,Timestamp,Trace_Match")] Measurement measurements)
        {
            if (ModelState.IsValid)
            {
                db.Measurements.Add(measurements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measurements);
        }

        // GET: Measurements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurements = db.Measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // POST: Measurements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BusId,Longitude,Latitude,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,Timestamp,Trace_Match")] Measurement measurements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measurements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measurements);
        }

        // GET: Measurements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Measurement measurements = db.Measurements.Find(id);
            if (measurements == null)
            {
                return HttpNotFound();
            }
            return View(measurements);
        }

        // POST: Measurements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measurement measurements = db.Measurements.Find(id);
            db.Measurements.Remove(measurements);
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
