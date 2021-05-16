namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Query")]
    public partial class Query
    {
        [Key]
        [Column(Order = 0)]
        public Guid CaseID { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(14)]
        public string CaseCode { get; set; }

        [StringLength(50)]
        public string ReferenceCode { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? TechnicalStaffID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? DealerID { get; set; }

        public Guid? ReimburseID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid ModelID { get; set; }

        public Guid? ModelUsedID { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BoughtDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        public string PlaceOfBuy { get; set; }

        [StringLength(50)]
        public string WCardNo { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? MadeDate { get; set; }

        public int? WarrantyTime { get; set; }

        public int? WarrantyStatus { get; set; }

        public int? WarrantyType { get; set; }

        public Guid? ConditionID { get; set; }

        public Guid? DefectCodeID { get; set; }

        public Guid? PositionCodeID { get; set; }

        public Guid? RepairCodeID { get; set; }

        public int? RepairType { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ReceivedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ScheduleStart { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ScheduleEnd { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CompleteDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ApprovalDate { get; set; }

        public int? Repeat { get; set; }

        [StringLength(250)]
        public string ReceivedBy { get; set; }

        public int? RepairStatus { get; set; }

        public Guid? MaplocationID { get; set; }

        public double? TripCost { get; set; }

        public double? LabourCost { get; set; }

        public double? ExtPartCost { get; set; }

        public double? TransCost { get; set; }

        public double? ReturnCost { get; set; }

        public double? PartPrice { get; set; }

        public double? ExchangeModelCost { get; set; }

        [Column(TypeName = "ntext")]
        public string CustomerSign { get; set; }

        public Guid? TicketID { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Description1 { get; set; }

        public Guid? CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        public int? RMonth { get; set; }

        public int? RYear { get; set; }

        public int? Km { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CompletedSVNOn { get; set; }

        public Guid? CompletedSVNBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? TechnicalCheckedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CompletedASCOn { get; set; }

        public Guid? CompletedASCBy { get; set; }

        [StringLength(50)]
        public string TEST { get; set; }
    }
}
