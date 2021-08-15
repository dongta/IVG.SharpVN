using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class GetJobForStaffEditDto
    {
        public AllJobAndRequest JobAndRequest { get; set; }
        public tbl_Customers Tbl_Customers { get; set; }
        public List<FileForView> Files { get; set; }

        public AllOptionSet AllOptionSet { get; set; }

        public bool NoEdit { get; set; }
        public GetJobForStaffEditDto()
        {
            JobAndRequest = new AllJobAndRequest();
            Tbl_Customers = new tbl_Customers();
            AllOptionSet = new AllOptionSet();
            NoEdit = false;
            Files = new List<FileForView>();
        }

    }
}