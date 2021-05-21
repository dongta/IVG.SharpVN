using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Home()
        {
            return View("Home");
        }
        public ActionResult SVC()
        {
            return View();
        }
        public ActionResult CRM()
        {
            return View();
        }
        public ActionResult ServiceLog()
        {
            return View();
        }
        public ActionResult JobDetail()
        {
            return View();
        }
        public ActionResult PrintOrder()
        {
            return View();
        }
    }
}