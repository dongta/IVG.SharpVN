using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            tbl_Users u = db.tbl_Users.FirstOrDefault(a=>a.UserName==User.Identity.Name);
            if (u.UserType==1)
            {
                return RedirectToAction("Home", "Staff");
            }
            else
            {
                return RedirectToAction("ServiceRequest", "Dealer");
            }
            return View(u);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}