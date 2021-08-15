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
        public List<FileForView> Files { get; set; }
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
    public class FileForView
    {
        public Guid ID { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        public byte[] Stream { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }
        public string Base64 { get; set; }
    }
}