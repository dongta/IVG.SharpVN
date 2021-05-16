namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ServiceCenters
    {
        [Key]
        public Guid ServiceCenterID { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(3)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public Guid? WardID { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? ProvinceID { get; set; }

        public Guid? AreaID { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Website { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string OtherPhone { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(20)]
        public string TaxCode { get; set; }

        public Guid? ParentServiceCenterID { get; set; }

        public bool? Type { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string ContractNo { get; set; }

        [StringLength(250)]
        public string Contractor { get; set; }

        public DateTime? ContractDate { get; set; }

        public DateTime? ToDate { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(20)]
        public string ContactPhone { get; set; }

        [StringLength(250)]
        public string BankAccount { get; set; }

        [StringLength(20)]
        public string BankNumber { get; set; }

        [StringLength(500)]
        public string BankName { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool? Main { get; set; }

        public int? SyncStatus { get; set; }

        public Guid? Owner { get; set; }
    }
}
