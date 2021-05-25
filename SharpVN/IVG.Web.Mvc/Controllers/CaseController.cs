using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    public class CaseController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Case
        public ActionResult Index()
        {
            return View();
        }
    }
}