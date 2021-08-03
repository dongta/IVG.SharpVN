using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class GetRequestForCreateOrEditDto
    {
        //public tbl_CasesRequest Tbl_CasesRequest { get; set; }
        public AllJobAndRequest RequestOrJob { get; set; }
        public tbl_Customers Tbl_Customers { get; set; }

        public AllOptionSet AllOptionSet { get; set; }

        public bool NoEdit { get; set; }
        public GetRequestForCreateOrEditDto()
        {
            //Tbl_CasesRequest = new tbl_CasesRequest();
            RequestOrJob = new AllJobAndRequest();
            Tbl_Customers = new tbl_Customers();
            AllOptionSet = new AllOptionSet();
            NoEdit = false;
        }

    }
}