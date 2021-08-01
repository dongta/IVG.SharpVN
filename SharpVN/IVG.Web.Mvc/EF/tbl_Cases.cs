namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Cases
    {
        [Key]
        public Guid CaseID { get; set; }
        public Guid? CaseRequestId { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(50)]
        public string CaseCode { get; set; }

        [StringLength(50)]
        public string ReferenceCode { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? TechnicalStaffID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? DealerID { get; set; }

        public Guid? ReimburseID { get; set; }

        public Guid ModelID { get; set; }

        public Guid? ModelUsedID { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

        public DateTime? BoughtDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(250)]
        public string PlaceOfBuy { get; set; }

        [StringLength(50)]
        public string WCardNo { get; set; }

        public DateTime? MadeDate { get; set; }

        public int? WarrantyTime { get; set; }

        public int? WarrantyStatus { get; set; }

        public int? WarrantyType { get; set; }

        public Guid? ConditionID { get; set; }

        public Guid? DefectCodeID { get; set; }

        public Guid? PositionCodeID { get; set; }

        public Guid? RepairCodeID { get; set; }

        public int? RepairType { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public DateTime? ScheduleStart { get; set; }

        public DateTime? ScheduleEnd { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

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

        public string CustomerSign { get; set; }

        public Guid? TicketID { get; set; }

        public string Description { get; set; }

        public string Description1 { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        public int? RMonth { get; set; }

        public int? RYear { get; set; }

        public int? Km { get; set; }

        public DateTime? CompletedSVNOn { get; set; }

        public Guid? CompletedSVNBy { get; set; }

        public DateTime? TechnicalCheckedOn { get; set; }

        public DateTime? CompletedASCOn { get; set; }

        public Guid? CompletedASCBy { get; set; }

        [StringLength(50)]
        public string TEST { get; set; }

        public DateTime? CreatedCustomerOn { get; set; }

        public Guid? CreatedCustomerBy { get; set; }
        public Guid? CancelReasonId { get; set; }
    }
}
