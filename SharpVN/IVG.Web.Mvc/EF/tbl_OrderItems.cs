namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_OrderItems
    {
        [Key]
        public Guid OrderID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? CaseID { get; set; }

        public Guid? FromServiceCenter { get; set; }

        public Guid? ToServiceCenter { get; set; }

        public Guid? FromStock { get; set; }

        public Guid ToStock { get; set; }

        public Guid? ParentOrder { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public bool? FOC { get; set; }

        public int? OrderType { get; set; }

        public int? Status { get; set; }

        public double? TotalPrice { get; set; }

        public double? TotalPriceReal { get; set; }

        public double? OtherPrice { get; set; }

        public string Description { get; set; }

        [StringLength(250)]
        public string ReferenceSO { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
