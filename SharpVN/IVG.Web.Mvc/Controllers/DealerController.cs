using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        // GET: Dealer
        public ActionResult Home()
        {
            return PartialView("Home");
        }
        public ActionResult ServiceRequest()
        {
            return View();
        }
        public ActionResult AddRequest()
        {
            return View();
        }
        public ActionResult ServiceDetail()
        {
            return View();
        }

    }
}