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
    public class ReferencesController : Controller
    {
        private BusDBEntities db = new BusDBEntities();

        // GET: References
        public ActionResult Index()
        {
            return View(db.References.ToList());
        }

        // GET: References/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference references = db.References.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // GET: References/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,From,To,duration,intervalTime")] Reference references)
        {
            if (ModelState.IsValid)
            {
                db.References.Add(references);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(references);
        }

        // GET: References/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference references = db.References.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,From,To,duration,intervalTime")] Reference references)
        {
            if (ModelState.IsValid)
            {
                db.Entry(references).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(references);
        }

        // GET: References/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference references = db.References.Find(id);
            if (references == null)
            {
                return HttpNotFound();
            }
            return View(references);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reference references = db.References.Find(id);
            db.References.Remove(references);
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
