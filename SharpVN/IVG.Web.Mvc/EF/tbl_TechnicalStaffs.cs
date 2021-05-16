namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_TechnicalStaffs
    {
        [Key]
        public Guid TechnicalStaffID { get; set; }

        public Guid? ServiceCenterID { get; set; }

        [StringLength(12)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(20)]
        public string IDNumber { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public Guid? WardID { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? ProvinceID { get; set; }

        [StringLength(20)]
        public string MobilePhone { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        [StringLength(20)]
        public string OfficePhone { get; set; }

        [StringLength(10)]
        public string Ext { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? Sex { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        public bool? Marriage { get; set; }

        public string Description { get; set; }

        public int? Status { get; set; }

        [StringLength(250)]
        public string Qualifications { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? CRMID { get; set; }

        public int? SyncStatus { get; set; }
    }
}
