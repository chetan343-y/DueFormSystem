using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DueFormSystem;

namespace DueFormSystem.Controllers
{
    public class tblLibrariesController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblLibraries
        public ActionResult Index()
        {
            var tblLibraries = db.tblLibraries.Include(t => t.tblStudent);
            return View(tblLibraries.ToList());
        }

        // GET: tblLibraries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrary tblLibrary = db.tblLibraries.Find(id);
            if (tblLibrary == null)
            {
                return HttpNotFound();
            }
            return View(tblLibrary);
        }

        // GET: tblLibraries/Create
        public ActionResult Create()
        {
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            return View();
        }

        // POST: tblLibraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,PendingBookingId,Fine")] tblLibrary tblLibrary)
        {
            if (ModelState.IsValid)
            {
                db.tblLibraries.Add(tblLibrary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblLibrary.PRNNo);
            return View(tblLibrary);
        }

        // GET: tblLibraries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrary tblLibrary = db.tblLibraries.Find(id);
            if (tblLibrary == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblLibrary.PRNNo);
            return View(tblLibrary);
        }

        // POST: tblLibraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,PendingBookingId,Fine")] tblLibrary tblLibrary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLibrary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblLibrary.PRNNo);
            return View(tblLibrary);
        }

        // GET: tblLibraries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLibrary tblLibrary = db.tblLibraries.Find(id);
            if (tblLibrary == null)
            {
                return HttpNotFound();
            }
            return View(tblLibrary);
        }

        // POST: tblLibraries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblLibrary tblLibrary = db.tblLibraries.Find(id);
            db.tblLibraries.Remove(tblLibrary);
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
