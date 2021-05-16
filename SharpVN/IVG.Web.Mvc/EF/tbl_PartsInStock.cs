namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PartsInStock
    {
        public Guid ID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? StockID { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        public int? Qty { get; set; }

        public int? OrderQty { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
