using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class DropdownItemDto
    {
        public string Id { get; set; }
        public string LookupId { get; set; }
        public string DisplayName { get; set; }
        public bool Selected { get; set; }
    }
}