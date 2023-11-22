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
    public class tblHostelsController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblHostels
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
            var tblHostels = db.tblHostels.Include(t => t.tblStudent).Include(t => t.tblYesNo);
            return View(tblHostels.ToList());
        }

        // GET: tblHostels/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHostel tblHostel = db.tblHostels.Find(id);
            if (tblHostel == null)
            {
                return HttpNotFound();
            }
            return View(tblHostel);
        }

        // GET: tblHostels/Create
        public ActionResult Create()
        {
            ViewBag.YesNoList = GetYesNo();
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            ViewBag.Member = new SelectList(db.tblYesNoes, "ID", "Value");
            return View();
        }

        // POST: tblHostels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,Member,PendingFee,Fine")] tblHostel tblHostel)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.tblHostels.Add(tblHostel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblHostel.PRNNo);
            ViewBag.Member = new SelectList(db.tblYesNoes, "ID", "Value", tblHostel.Member);
            return View(tblHostel);
        }

        // GET: tblHostels/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHostel tblHostel = db.tblHostels.Find(id);
            if (tblHostel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblHostel.PRNNo);
            ViewBag.Member = new SelectList(db.tblYesNoes, "ID", "Value", tblHostel.Member);
            return View(tblHostel);
        }

        // POST: tblHostels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,Member,PendingFee,Fine")] tblHostel tblHostel)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.Entry(tblHostel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblHostel.PRNNo);
            ViewBag.Member = new SelectList(db.tblYesNoes, "ID", "Value", tblHostel.Member);
            return View(tblHostel);
        }

        // GET: tblHostels/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHostel tblHostel = db.tblHostels.Find(id);
            if (tblHostel == null)
            {
                return HttpNotFound();
            }
            return View(tblHostel);
        }

        // POST: tblHostels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            tblHostel tblHostel = db.tblHostels.Find(id);
            db.tblHostels.Remove(tblHostel);
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
