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
    public class tblStudentsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblStudents
        public List<SelectListItem> GetBranch()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var BranchList = ctx.tblBranches.ToList();
                foreach (var item in BranchList)
                {
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Branch;
                    temp.Value = item.Id.ToString();
                    obj.Add(temp);
                }
            }
            return obj;
        }

        public List<SelectListItem> GetGender()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var GenderList = ctx.tblGenders.ToList();
                foreach (var item in GenderList)
                {
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Gender;
                    temp.Value = item.Id.ToString();
                    obj.Add(temp);
                }
            }
            return obj;
        }
        public List<SelectListItem> GetCaste()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var CasteList = ctx.tblCastes.ToList();
                foreach (var item in CasteList)
                {
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Caste;
                    temp.Value = item.Id.ToString();
                    obj.Add(temp);
                }
            }
            return obj;
        }
        public ActionResult Index()
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            var tblStudents = db.tblStudents.Include(t => t.tblAccountSection).Include(t => t.tblBranch).Include(t => t.tblCaste).Include(t => t.tblDepartement).Include(t => t.tblGender).Include(t => t.tblGym).Include(t => t.tblHostel).Include(t => t.tblLibrary).Include(t => t.tblScholarship).Include(t => t.tblStudentSection).Include(t => t.tblTPO);
            return View(tblStudents.ToList());
        }

        // GET: tblStudents/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: tblStudents/Create
        public ActionResult Create()
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            ViewBag.PRNNo = new SelectList(db.tblAccountSections, "PRNNo", "PRNNo");
            ViewBag.Branch = new SelectList(db.tblBranches, "Id", "Branch");
            ViewBag.Gender = new SelectList(db.tblCastes, "Id", "Caste");
            ViewBag.PRNNo = new SelectList(db.tblDepartements, "PRNNo", "PRNNo");
            ViewBag.Gender = new SelectList(db.tblGenders, "Id", "Gender");
            ViewBag.PRNNo = new SelectList(db.tblGyms, "PRNNo", "Role");
            ViewBag.PRNNo = new SelectList(db.tblHostels, "PRNNo", "PRNNo");
            ViewBag.PRNNo = new SelectList(db.tblLibraries, "PRNNo", "PendingBookingId");
            ViewBag.PRNNo = new SelectList(db.tblScholarships, "PRNNo", "PRNNo");
            ViewBag.PRNNo = new SelectList(db.tblStudentSections, "PRNNo", "PRNNo");
            ViewBag.PRNNo = new SelectList(db.tblTPOes, "PRNNo", "PRNNo");
            return View();
        }

        // POST: tblStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,Name,Branch,Gender,Caste,DOB,PhoneNo,Email")] tblStudent tblStudent)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(tblStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblAccountSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Branch = new SelectList(db.tblBranches, "Id", "Branch", tblStudent.Branch);
            ViewBag.Gender = new SelectList(db.tblCastes, "Id", "Caste", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblDepartements, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Gender = new SelectList(db.tblGenders, "Id", "Gender", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblGyms, "PRNNo", "Role", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblHostels, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblLibraries, "PRNNo", "PendingBookingId", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblScholarships, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblStudentSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblTPOes, "PRNNo", "PRNNo", tblStudent.PRNNo);
            return View(tblStudent);
        }

        // GET: tblStudents/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblAccountSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Branch = new SelectList(db.tblBranches, "Id", "Branch", tblStudent.Branch);
            ViewBag.Gender = new SelectList(db.tblCastes, "Id", "Caste", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblDepartements, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Gender = new SelectList(db.tblGenders, "Id", "Gender", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblGyms, "PRNNo", "Role", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblHostels, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblLibraries, "PRNNo", "PendingBookingId", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblScholarships, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblStudentSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblTPOes, "PRNNo", "PRNNo", tblStudent.PRNNo);
            return View(tblStudent);
        }

        // POST: tblStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,Name,Branch,Gender,Caste,DOB,PhoneNo,Email")] tblStudent tblStudent)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblAccountSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Branch = new SelectList(db.tblBranches, "Id", "Branch", tblStudent.Branch);
            ViewBag.Gender = new SelectList(db.tblCastes, "Id", "Caste", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblDepartements, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.Gender = new SelectList(db.tblGenders, "Id", "Gender", tblStudent.Gender);
            ViewBag.PRNNo = new SelectList(db.tblGyms, "PRNNo", "Role", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblHostels, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblLibraries, "PRNNo", "PendingBookingId", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblScholarships, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblStudentSections, "PRNNo", "PRNNo", tblStudent.PRNNo);
            ViewBag.PRNNo = new SelectList(db.tblTPOes, "PRNNo", "PRNNo", tblStudent.PRNNo);
            return View(tblStudent);
        }

        // GET: tblStudents/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: tblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            tblStudent tblStudent = db.tblStudents.Find(id);
            db.tblStudents.Remove(tblStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ViewBag.GenderList = GetGender();
            ViewBag.CasteList = GetCaste();
            ViewBag.BranchList = GetBranch();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
