using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace DueFormSystem.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: LoginAdmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AdminLogin obj)
        {
            using (var ctx = new DueCheckDatabaseEntities())
            {
                var ExistingUser = ctx.tblAdmins.Where(w => w.Id == obj.ToString() && w.Password == obj.ToString());
                if (ExistingUser != null)
                {
                    FormsAuthentication.SetAuthCookie(obj.ToString(), false);
                    return RedirectToAction("Home", "LoginAdmin");
                }
                else
                {
                    ViewBag.msg = "Invalid Credentails";
                }
            }
            return View();
        }
         public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(int i=0)
        {
            return View();
        }
    }
}