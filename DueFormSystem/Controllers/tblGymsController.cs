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
    public class tblGymsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblGyms
        public ActionResult Index()
        {
            var tblGyms = db.tblGyms.Include(t => t.tblStudent);
            return View(tblGyms.ToList());
        }

        // GET: tblGyms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGym tblGym = db.tblGyms.Find(id);
            if (tblGym == null)
            {
                return HttpNotFound();
            }
            return View(tblGym);
        }

        // GET: tblGyms/Create
        public ActionResult Create()
        {
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            return View();
        }

        // POST: tblGyms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,Role,Fine")] tblGym tblGym)
        {
            if (ModelState.IsValid)
            {
                db.tblGyms.Add(tblGym);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblGym.PRNNo);
            return View(tblGym);
        }

        // GET: tblGyms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGym tblGym = db.tblGyms.Find(id);
            if (tblGym == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblGym.PRNNo);
            return View(tblGym);
        }

        // POST: tblGyms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,Role,Fine")] tblGym tblGym)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGym).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblGym.PRNNo);
            return View(tblGym);
        }

        // GET: tblGyms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGym tblGym = db.tblGyms.Find(id);
            if (tblGym == null)
            {
                return HttpNotFound();
            }
            return View(tblGym);
        }

        // POST: tblGyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblGym tblGym = db.tblGyms.Find(id);
            db.tblGyms.Remove(tblGym);
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
