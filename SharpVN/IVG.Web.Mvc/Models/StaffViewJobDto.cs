using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class StaffViewJobDto
    {
        public AllJobAndRequest AllJobAndRequest { get; set; }
        public AllOptionSet AllOptionSet { get; set; }

    }
}