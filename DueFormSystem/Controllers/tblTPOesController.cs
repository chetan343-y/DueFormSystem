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
    public class tblTPOesController : Controller
    {
        private DueCheckDatabaseEntities db = new DueCheckDatabaseEntities();

        // GET: tblTPOes
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
            var tblTPOes = db.tblTPOes.Include(t => t.tblStudent).Include(t => t.tblYesNo);
            return View(tblTPOes.ToList());
        }

        // GET: tblTPOes/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTPO tblTPO = db.tblTPOes.Find(id);
            if (tblTPO == null)
            {
                return HttpNotFound();
            }
            return View(tblTPO);
        }

        // GET: tblTPOes/Create
        public ActionResult Create()
        {
            ViewBag.YesNoList = GetYesNo();
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name");
            ViewBag.PlacementStatus = new SelectList(db.tblYesNoes, "ID", "Value");
            return View();
        }

        // POST: tblTPOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRNNo,PlacementStatus,ActivtyCompleted")] tblTPO tblTPO)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.tblTPOes.Add(tblTPO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblTPO.PRNNo);
            ViewBag.PlacementStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblTPO.PlacementStatus);
            return View(tblTPO);
        }

        // GET: tblTPOes/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTPO tblTPO = db.tblTPOes.Find(id);
            if (tblTPO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblTPO.PRNNo);
            ViewBag.PlacementStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblTPO.PlacementStatus);
            return View(tblTPO);
        }

        // POST: tblTPOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRNNo,PlacementStatus,ActivtyCompleted")] tblTPO tblTPO)
        {
            ViewBag.YesNoList = GetYesNo();
            if (ModelState.IsValid)
            {
                db.Entry(tblTPO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRNNo = new SelectList(db.tblStudents, "PRNNo", "Name", tblTPO.PRNNo);
            ViewBag.PlacementStatus = new SelectList(db.tblYesNoes, "ID", "Value", tblTPO.PlacementStatus);
            return View(tblTPO);
        }

        // GET: tblTPOes/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTPO tblTPO = db.tblTPOes.Find(id);
            if (tblTPO == null)
            {
                return HttpNotFound();
            }
            return View(tblTPO);
        }

        // POST: tblTPOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewBag.YesNoList = GetYesNo();
            tblTPO tblTPO = db.tblTPOes.Find(id);
            db.tblTPOes.Remove(tblTPO);
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
