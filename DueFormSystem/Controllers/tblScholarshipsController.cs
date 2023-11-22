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
    public class tblScholarshipsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblScholarships
        public List<SelectListItem> GetYesNo()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var YesNoList = ctx.tblYesNoes.ToList();
                foreach (var item in YesNoList)
                {
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Value;
                    temp.Value = item.ID.ToString();
                    obj.Add(temp);
                }
            }
            return obj;
        }
        public ActionResult Index()
        {
            ViewBag.YesNoList = GetYesNo();
            var tblScholarships = db.tblScholarships.Include(t => t.tblStudent).Include(t => t.tblYesNo);
            return View(tblScholarships.ToList());
        }

        // GET: tblScholarships/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblScholarship tblScholarship = db.tblScholarships.Find(id);
            if (tblScholarship == null)
            {
                return HttpNotFound();
            }
            return View(tblScholarship);
        }

        // GET: tblScholarships/Create
        public ActionResult Create()
        {
            ViewBag.YesNoList = GetYesNo();
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            ViewBag.Authenticate = new SelectList(db.tblYesNoes, "ID", "Value");
            return View();
        }

        // POST: tblScholarships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,ScholarshipRemFromCollege,NumberofScholarship,Authenticate")] tblScholarship tblScholarship)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.tblScholarships.Add(tblScholarship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblScholarship.PRNNo);
            ViewBag.Authenticate = new SelectList(db.tblYesNoes, "ID", "Value", tblScholarship.Authenticate);
            return View(tblScholarship);
        }

        // GET: tblScholarships/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblScholarship tblScholarship = db.tblScholarships.Find(id);
            if (tblScholarship == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblScholarship.PRNNo);
            ViewBag.Authenticate = new SelectList(db.tblYesNoes, "ID", "Value", tblScholarship.Authenticate);
            return View(tblScholarship);
        }

        // POST: tblScholarships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,ScholarshipRemFromCollege,NumberofScholarship,Authenticate")] tblScholarship tblScholarship)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.Entry(tblScholarship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblScholarship.PRNNo);
            ViewBag.Authenticate = new SelectList(db.tblYesNoes, "ID", "Value", tblScholarship.Authenticate);
            return View(tblScholarship);
        }

        // GET: tblScholarships/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblScholarship tblScholarship = db.tblScholarships.Find(id);
            if (tblScholarship == null)
            {
                return HttpNotFound();
            }
            return View(tblScholarship);
        }

        // POST: tblScholarships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            tblScholarship tblScholarship = db.tblScholarships.Find(id);
            db.tblScholarships.Remove(tblScholarship);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ViewBag.YesNoList = GetYesNo();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
