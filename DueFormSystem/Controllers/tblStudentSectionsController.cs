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
    public class tblStudentSectionsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblStudentSections
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
            var tblStudentSections = db.tblStudentSections.Include(t => t.tblStudent).Include(t => t.tblYesNo).Include(t => t.tblYesNo1).Include(t => t.tblYesNo2);
            return View(tblStudentSections.ToList());
        }

        // GET: tblStudentSections/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentSection tblStudentSection = db.tblStudentSections.Find(id);
            if (tblStudentSection == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentSection);
        }

        // GET: tblStudentSections/Create
        public ActionResult Create()
        {
            ViewBag.YesNoList = GetYesNo();
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            ViewBag.CheckDue = new SelectList(db.tblYesNoes, "ID", "Value");
            ViewBag.Backlog = new SelectList(db.tblYesNoes, "ID", "Value");
            ViewBag.PendingProject = new SelectList(db.tblYesNoes, "ID", "Value");
            return View();
        }

        // POST: tblStudentSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,Backlog,PendingFee,PendingProject,CheckDue")] tblStudentSection tblStudentSection)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.tblStudentSections.Add(tblStudentSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblStudentSection.PRNNo);
            ViewBag.CheckDue = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.CheckDue);
            ViewBag.Backlog = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.Backlog);
            ViewBag.PendingProject = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.PendingProject);
            return View(tblStudentSection);
        }

        // GET: tblStudentSections/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentSection tblStudentSection = db.tblStudentSections.Find(id);
            if (tblStudentSection == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblStudentSection.PRNNo);
            ViewBag.CheckDue = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.CheckDue);
            ViewBag.Backlog = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.Backlog);
            ViewBag.PendingProject = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.PendingProject);
            return View(tblStudentSection);
        }

        // POST: tblStudentSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,Backlog,PendingFee,PendingProject,CheckDue")] tblStudentSection tblStudentSection)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.Entry(tblStudentSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblStudentSection.PRNNo);
            ViewBag.CheckDue = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.CheckDue);
            ViewBag.Backlog = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.Backlog);
            ViewBag.PendingProject = new SelectList(db.tblYesNoes, "ID", "Value", tblStudentSection.PendingProject);
            return View(tblStudentSection);
        }

        // GET: tblStudentSections/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentSection tblStudentSection = db.tblStudentSections.Find(id);
            if (tblStudentSection == null)
            {
                return HttpNotFound();
            }
            return View(tblStudentSection);
        }

        // POST: tblStudentSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            tblStudentSection tblStudentSection = db.tblStudentSections.Find(id);
            db.tblStudentSections.Remove(tblStudentSection);
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
