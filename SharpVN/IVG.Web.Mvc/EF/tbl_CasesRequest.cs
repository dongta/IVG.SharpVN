namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CasesRequest
    {
        [Key]
        public Guid CaseID { get; set; }

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
    }
}
