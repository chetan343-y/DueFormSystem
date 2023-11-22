using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DueFormSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Choice()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Choice(int num = 0)
        {
            return View();
        }
    }
}