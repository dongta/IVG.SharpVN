using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class Paging
    {
        public int Start { get; set; }
        public int Length{ get; set; }
        public int Draw { get; set; }
    }
}