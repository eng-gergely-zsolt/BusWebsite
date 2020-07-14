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
    public class CarDatasController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: CarDatas
        public ActionResult Index()
        {
            var carData = db.CarDatas.Include(c => c.Bus);
            return View(carData.ToList());
        }

        // GET: CarDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarData carData = db.CarDatas.Find(id);
            if (carData == null)
            {
                return HttpNotFound();
            }
            return View(carData);
        }

        // GET: CarDatas/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            return View();
        }

        // POST: CarDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Longitude,Latitude,Measurement_Timestamp,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,BusId,Trace_Match")] CarData carData)
        {
            if (ModelState.IsValid)
            {
                db.CarDatas.Add(carData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", carData.BusId);
            return View(carData);
        }

        // GET: CarDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarData carData = db.CarDatas.Find(id);
            if (carData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", carData.BusId);
            return View(carData);
        }

        // POST: CarDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Longitude,Latitude,Measurement_Timestamp,Position_Accuracy,Speed,Speed_Accuracy,Direction,Accel_x,Accel_y,Accel_z,Gyro_x,Gyro_y,Gyro_z,BusId,Trace_Match")] CarData carData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", carData.BusId);
            return View(carData);
        }

        // GET: CarDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarData carData = db.CarDatas.Find(id);
            if (carData == null)
            {
                return HttpNotFound();
            }
            return View(carData);
        }

        // POST: CarDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarData carData = db.CarDatas.Find(id);
            db.CarDatas.Remove(carData);
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
