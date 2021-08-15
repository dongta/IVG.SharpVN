using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public PartialViewResult ImageModal()
        {
            return PartialView("ImageModal");
        }
    }
}