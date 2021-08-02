namespace IVG.Web.Mvc.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_CasesRequest
    {
        [Key]
        public Guid CaseID { get; set; }
        public string RequestCode { get; set; }
        
        public Guid? CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        public Guid? ProvinceID { get; set; }

        public Guid? WardsID { get; set; }

        public Guid? DistrictID { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ModelCode { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        public Guid? ModelID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

        public string PurchasePlace { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public string CustomerSign { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ApprovedBy { get; set; }

        public DateTime? ApprovedOn { get; set; }

        public int? Status { get; set; }

        [StringLength(500)]
        public string RejectReason { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string ReferenceCode { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? TechnicalStaffID { get; set; }

        public Guid? ModelUsedID { get; set; }

        public Guid? SupplierID { get; set; }

        public DateTime? BoughtDate { get; set; }

        [StringLength(250)]
        public string PlaceOfBuy { get; set; }

        [StringLength(50)]
        public string WCardNo { get; set; }

        public DateTime? MadeDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? WarrantyTime { get; set; }

        public int? WarrantyStatus { get; set; }

        public int? WarrantyType { get; set; }

        public Guid? ConditionID { get; set; }

        public Guid? DefectID { get; set; }

        public string Description { get; set; }

        public string SVNDescript { get; set; }

        public int? RepairType { get; set; }

        [StringLength(250)]
        public string ReceivedBy { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? SyncStatus { get; set; }

        public int? Repeat { get; set; }

        public DateTime? TechnicalCheckedOn { get; set; }

        public Guid? ConvertBy { get; set; }

        public DateTime? ConvertOn { get; set; }
        public Guid? CancelReasonId { get; set; }
    }
}
