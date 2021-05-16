namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PartReplace
    {
        public Guid ID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? PartID { get; set; }

        public Guid? CaseID { get; set; }

        [StringLength(50)]
        public string NewSerialNo { get; set; }

        [StringLength(50)]
        public string DefectSerialNo { get; set; }

        public Guid? OrderID { get; set; }

        [StringLength(250)]
        public string ReferenceSO { get; set; }

        public int? Qty { get; set; }

        public double? PartPrice { get; set; }

        public double? TotalPrice { get; set; }

        [StringLength(250)]
        public string Partoutside { get; set; }

        public double? ExtPartPrice { get; set; }

        public DateTime? RepairedOn { get; set; }

        public int? RepairedMode { get; set; }

        [Column(TypeName = "image")]
        public byte[] Images { get; set; }

        public int? Received { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? PaymentStatus { get; set; }

        public bool? PurchasedOutSide { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        [StringLength(250)]
        public string SOCode { get; set; }
    }
}
