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
    public class MeasuredDatasController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: MeasuredDatas
        public ActionResult Index()
        {
            return View(db.MeasuredDatas.ToList());
        }

        // GET: MeasuredDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuredData measuredData = db.MeasuredDatas.Find(id);
            if (measuredData == null)
            {
                return HttpNotFound();
            }
            return View(measuredData);
        }

        // GET: MeasuredDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MeasuredDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,From,To,duration,dateTime")] MeasuredData measuredData)
        {
            if (ModelState.IsValid)
            {
                db.MeasuredDatas.Add(measuredData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(measuredData);
        }

        // GET: MeasuredDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuredData measuredData = db.MeasuredDatas.Find(id);
            if (measuredData == null)
            {
                return HttpNotFound();
            }
            return View(measuredData);
        }

        // POST: MeasuredDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,From,To,duration,dateTime")] MeasuredData measuredData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measuredData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(measuredData);
        }

        // GET: MeasuredDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MeasuredData measuredData = db.MeasuredDatas.Find(id);
            if (measuredData == null)
            {
                return HttpNotFound();
            }
            return View(measuredData);
        }

        // POST: MeasuredDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MeasuredData measuredData = db.MeasuredDatas.Find(id);
            db.MeasuredDatas.Remove(measuredData);
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
