using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class BasicFilter:Paging
    {
        public string FilterText { get; set; }
    }
}