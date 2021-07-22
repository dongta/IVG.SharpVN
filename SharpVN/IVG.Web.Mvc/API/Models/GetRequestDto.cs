using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class GetRequestDto:Paging
    {
        public string filterText { get; set; }

        public GetRequestDto()
        {
            Draw = 1;
            Start = 0;
            Length = 10;
        }
    }
}