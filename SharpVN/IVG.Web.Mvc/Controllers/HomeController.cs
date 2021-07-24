using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            tbl_Users u = db.tbl_Users.FirstOrDefault(a=>a.UserName==User.Identity.Name);
            FormsIdentity formsIdentity = User.Identity as FormsIdentity;
            FormsAuthenticationTicket ticket = formsIdentity.Ticket;
            var roleCookie = Request.Cookies["role"];
            var roleName = roleCookie?.Values["rolename"] ?? string.Empty;
            if (roleName.ToLower()==AppEnum.Role.Staff.ToString().ToLower())
            {
                return RedirectToAction("Home", "Staff");
            }
            else if (roleName.ToLower() == AppEnum.Role.Dealer.ToString().ToLower())
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