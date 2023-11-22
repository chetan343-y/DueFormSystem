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
    public class tblDepartementsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblDepartements
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
            var tblDepartements = db.tblDepartements.Include(t => t.tblStudent).Include(t => t.tblYesNo).Include(t => t.tblYesNo1);
            return View(tblDepartements.ToList());
        }

        // GET: tblDepartements/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartement tblDepartement = db.tblDepartements.Find(id);
            if (tblDepartement == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartement);
        }

        // GET: tblDepartements/Create
        public ActionResult Create()
        {
            ViewBag.YesNoList = GetYesNo();
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            ViewBag.ProjectStatus = new SelectList(db.tblYesNoes, "ID", "Value");
            ViewBag.Pass = new SelectList(db.tblYesNoes, "ID", "Value");
            return View();
        }

        // POST: tblDepartements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,ProjectStatus,Backlog,CGPA,Pass")] tblDepartement tblDepartement)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.tblDepartements.Add(tblDepartement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblDepartement.PRNNo);
            ViewBag.ProjectStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.ProjectStatus);
            ViewBag.Pass = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.Pass);
            return View(tblDepartement);
        }

        // GET: tblDepartements/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartement tblDepartement = db.tblDepartements.Find(id);
            if (tblDepartement == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblDepartement.PRNNo);
            ViewBag.ProjectStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.ProjectStatus);
            ViewBag.Pass = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.Pass);
            return View(tblDepartement);
        }

        // POST: tblDepartements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,ProjectStatus,Backlog,CGPA,Pass")] tblDepartement tblDepartement)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.Entry(tblDepartement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblDepartement.PRNNo);
            ViewBag.ProjectStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.ProjectStatus);
            ViewBag.Pass = new SelectList(db.tblYesNoes, "ID", "Value", tblDepartement.Pass);
            return View(tblDepartement);
        }

        // GET: tblDepartements/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDepartement tblDepartement = db.tblDepartements.Find(id);
            if (tblDepartement == null)
            {
                return HttpNotFound();
            }
            return View(tblDepartement);
        }

        // POST: tblDepartements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            tblDepartement tblDepartement = db.tblDepartements.Find(id);
            db.tblDepartements.Remove(tblDepartement);
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
