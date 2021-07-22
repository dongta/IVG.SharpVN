using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class PagedResultDto
    {
        public long Draw { get; set; }
        public long RecordsTotal { get; set; }
        public long recordsFiltered { get; set; }
        public object Data { get; set; }
    }
}