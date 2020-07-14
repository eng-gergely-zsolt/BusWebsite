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
    public class BusDriverDatasController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: BusDriverDatas
        public ActionResult Index()
        {
            var busDriverData = db.BusDriverDatas.Include(b => b.Bus);
            return View(busDriverData.ToList());
        }

        // GET: BusDriverDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverData busDriverData = db.BusDriverDatas.Find(id);
            if (busDriverData == null)
            {
                return HttpNotFound();
            }
            return View(busDriverData);
        }

        // GET: BusDriverDatas/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            return View();
        }

        // POST: BusDriverDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Longitude,Latitude,Measurement_Timestamp,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,BusId,Trace_Match")] BusDriverData busDriverData)
        {
            if (ModelState.IsValid)
            {
                db.BusDriverDatas.Add(busDriverData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busDriverData.BusId);
            return View(busDriverData);
        }

        // GET: BusDriverDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverData busDriverData = db.BusDriverDatas.Find(id);
            if (busDriverData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busDriverData.BusId);
            return View(busDriverData);
        }

        // POST: BusDriverDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Longitude,Latitude,Measurement_Timestamp,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,BusId,Trace_Match")] BusDriverData busDriverData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busDriverData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", busDriverData.BusId);
            return View(busDriverData);
        }

        // GET: BusDriverDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusDriverData busDriverData = db.BusDriverDatas.Find(id);
            if (busDriverData == null)
            {
                return HttpNotFound();
            }
            return View(busDriverData);
        }

        // POST: BusDriverDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusDriverData busDriverData = db.BusDriverDatas.Find(id);
            db.BusDriverDatas.Remove(busDriverData);
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
