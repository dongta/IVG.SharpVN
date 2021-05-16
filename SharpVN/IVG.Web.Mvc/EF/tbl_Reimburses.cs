namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Reimburses
    {
        [Key]
        public Guid ReimburseID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? ServiceCenterID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int? Rmonth { get; set; }

        public int? Ryear { get; set; }

        public double? LabourCost { get; set; }

        public double? ExtPartCost { get; set; }

        public double? TransCost { get; set; }

        public double? TripCost { get; set; }

        public double? PostalFee { get; set; }

        public double? PhoneFee { get; set; }

        public double? OthersFee { get; set; }

        public double? MiscCost { get; set; }

        public double? PartCost { get; set; }

        public double? ExchangeCost { get; set; }

        public int? PaymentStatus { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
