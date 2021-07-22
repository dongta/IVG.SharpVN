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
        public long RecordsFiltered { get; set; }
        public object Data { get; set; }
        public PagedResultDto(long draw,long totalRecords,long filteredRecords,object data)
        {
            this.Draw = draw;
            RecordsTotal = totalRecords;
            RecordsFiltered = filteredRecords;
            Data = data;
        }
    }
}