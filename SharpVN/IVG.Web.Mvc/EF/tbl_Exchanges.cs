namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Exchanges
    {
        [Key]
        public Guid ExchangeID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? CaseID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(250)]
        public string ReferenceSO { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? DefectModelID { get; set; }

        [StringLength(50)]
        public string DefectWCardNo { get; set; }

        [StringLength(50)]
        public string DefectSerialNo { get; set; }

        public Guid? DefectCodeID { get; set; }

        public Guid? ReasonID { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public DateTime? AuditDate { get; set; }

        public Guid? NewModelID { get; set; }

        [StringLength(50)]
        public string NewWCardNo { get; set; }

        [StringLength(50)]
        public string NewSerialNo { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public double? Amount { get; set; }

        public int? Reimburse { get; set; }

        public int? PaymentStatus { get; set; }

        public Guid? StockID { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
