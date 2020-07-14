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
    public class BusTracesController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: BusTraces
        public ActionResult Index()
        {
            return View(db.BusTraces.ToList());
        }

        // GET: BusTraces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTrace busTrace = db.BusTraces.Find(id);
            if (busTrace == null)
            {
                return HttpNotFound();
            }
            return View(busTrace);
        }

        // GET: BusTraces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusTraces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BusId,Longitude,Latitude,Timestamp")] BusTrace busTrace)
        {
            if (ModelState.IsValid)
            {
                db.BusTraces.Add(busTrace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busTrace);
        }

        // GET: BusTraces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTrace busTrace = db.BusTraces.Find(id);
            if (busTrace == null)
            {
                return HttpNotFound();
            }
            return View(busTrace);
        }

        // POST: BusTraces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BusId,Longitude,Latitude,Timestamp")] BusTrace busTrace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busTrace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busTrace);
        }

        // GET: BusTraces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusTrace busTrace = db.BusTraces.Find(id);
            if (busTrace == null)
            {
                return HttpNotFound();
            }
            return View(busTrace);
        }

        // POST: BusTraces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusTrace busTrace = db.BusTraces.Find(id);
            db.BusTraces.Remove(busTrace);
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
