namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SafetyStock
    {
        public Guid ID { get; set; }

        public Guid? CRMID { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? StockID { get; set; }

        public int? AvailableNumber { get; set; }

        public int? WarningNumber { get; set; }

        public int? AutoWarning { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
