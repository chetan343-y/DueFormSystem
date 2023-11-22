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
    public class tblAccountSectionsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblAccountSections
        public ActionResult Index()
        {
            var tblAccountSections = db.tblAccountSections.Include(t => t.tblStudent);
            return View(tblAccountSections.ToList());
        }

        // GET: tblAccountSections/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountSection tblAccountSection = db.tblAccountSections.Find(id);
            if (tblAccountSection == null)
            {
                return HttpNotFound();
            }
            return View(tblAccountSection);
        }

        // GET: tblAccountSections/Create
        public ActionResult Create()
        {
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            return View();
        }

        // POST: tblAccountSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,PendingFee")] tblAccountSection tblAccountSection)
        {
            if (ModelState.IsValid)
            {
                db.tblAccountSections.Add(tblAccountSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblAccountSection.PRNNo);
            return View(tblAccountSection);
        }

        // GET: tblAccountSections/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountSection tblAccountSection = db.tblAccountSections.Find(id);
            if (tblAccountSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblAccountSection.PRNNo);
            return View(tblAccountSection);
        }

        // POST: tblAccountSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,PendingFee")] tblAccountSection tblAccountSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAccountSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblAccountSection.PRNNo);
            return View(tblAccountSection);
        }

        // GET: tblAccountSections/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountSection tblAccountSection = db.tblAccountSections.Find(id);
            if (tblAccountSection == null)
            {
                return HttpNotFound();
            }
            return View(tblAccountSection);
        }

        // POST: tblAccountSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblAccountSection tblAccountSection = db.tblAccountSections.Find(id);
            db.tblAccountSections.Remove(tblAccountSection);
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
