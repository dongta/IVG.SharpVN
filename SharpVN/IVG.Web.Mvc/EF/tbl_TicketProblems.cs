namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TicketProblems
    {
        [Key]
        public Guid TicketID { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string ReferenceCode { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? TechnicalStaffID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? ModelID { get; set; }

        public Guid? ModelUsedID { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

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

        public int? Status { get; set; }

        public int? RepairType { get; set; }

        [StringLength(250)]
        public string ReceivedBy { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public int? SyncStatus { get; set; }

        public int? Repeat { get; set; }

        public DateTime? TechnicalCheckedOn { get; set; }

        public Guid? ConvertBy { get; set; }

        public DateTime? ConvertOn { get; set; }
    }
}
