using DueFormSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DueFormSystem.Controllers
{
    public class LoginStudentController : Controller
    {
        // GET: LoginStudent
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

        public List<SelectListItem> GetBranch()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var GenderList = ctx.tblBranches.ToList();
                foreach (var item in GenderList)
                {
                    SelectListItem temp = new SelectListItem();
                    temp.Text = item.Branch;
                    temp.Value = item.Id.ToString();
                    obj.Add(temp);
                }
            }
            return obj;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(StudentLogin obj)
        {
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var ExistingUser = ctx.tblStudentLogins.Where(w => w.PRNNo == obj.AdminName && w.Password == obj.Password);
                if (ExistingUser != null)
                {
                    FormsAuthentication.SetAuthCookie(obj.AdminName, false);
                    return RedirectToAction("Display", "LoginStudent", new { PRN = obj.AdminName });
                }
                else
                {
                    ViewBag.msg = "Invalid Credentails";
                }
            }
            return View();
        }


        public ActionResult Home(string PRNNo = "0")
        {
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var obj1 = ctx.tblStudents.Find(PRNNo);
                if (obj1 != null)
                {
                    return RedirectToAction("Display", "LoginStudent", new { PRN = obj1.PRNNo });
                }
                ViewBag.Part1 = ctx.tblStudents.Include("tblGender").Include("tblBranch").ToList();
                if (PRNNo != "0")
                {
                    var obj = ctx.tblStudents.Find(PRNNo);
                    if (obj != null)
                    {
                        return RedirectToAction("Display", "LoginStudent", new { PRN = obj.PRNNo }); 
                    }
                }
                ViewBag.GenderList = GetGender();
                ViewBag.BranchList = GetBranch();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Home(tblStudent obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var ctx = new DueCheckDatabaseEntities())

                    {
                        ctx.tblStudents.Add(obj);
                        ctx.SaveChanges();

                        return RedirectToAction("Display", "LoginStudent", new { PRN = obj.PRNNo });   //Next Page Create
                    }
                }
            }
            catch (Exception err)
            {
                ViewBag.msg = "Failed- " + err.Message;
            }
            ViewBag.GenderList = GetGender();
            ViewBag.BranchList = GetBranch();
            return View();
        }

        public ActionResult Display(string PRN)
        {
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var obj = ctx.tblStudents.Find(PRN);
                var branch = ctx.tblBranches.Find(obj.Branch);
                List<string> itemsList1 = new List<string>
                {obj.PRNNo,
                    obj.Email,
                    obj.PhoneNo.ToString(),
                    obj.Name,
                    obj.DOB.ToString(),
                    branch.Branch.ToString()
                };
                ViewBag.Part1 = itemsList1;
                var obj2 = ctx.tblGyms.Find(PRN);
                List<string> itemsList2 = new List<string>
                {
                    obj2.Fine.ToString(),

                };
                ViewBag.Part2 = itemsList2;
                var obj3 = ctx.tblStudentSections.Find(PRN);
                List<string> itemsList3 = new List<string>
                {
                    obj3.PendingFee.ToString(),
                    obj3.CheckDue.ToString()
                };
                ViewBag.Part3 = itemsList3;
                var obj4 = ctx.tblAccountSections.Find(PRN);
                List<string> itemsList4 = new List<string>
                {
                    obj4.PendingFee.ToString()
                };
                ViewBag.Part4 = itemsList4;
 
                var obj5 = ctx.tblHostels.Find(PRN);
                List<string> itemsList5 = new List<string>
                {
                    obj5.PendingFee.ToString(),
                    obj5.Fine.ToString()
                };
                ViewBag.Part5 = itemsList5;

                var obj6 = ctx.tblLibraries.Find(PRN);
                List<string> itemsList6 = new List<string>
                {
                    obj6.Fine.ToString()
                };
                ViewBag.Part6 = itemsList6;


                var obj7 = ctx.tblScholarships.Find(PRN);
                List<string> itemsList7 = new List<string>
                {
                    obj7.ScholarshipRemFromCollege.ToString()
                };
                ViewBag.Part7 = itemsList7;
                return View();
            }
        }

        public ActionResult Pay()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pay(int p=0)
        {
            return View();
        }
        public ActionResult Method()
        {
            return View();
        }
    }
}