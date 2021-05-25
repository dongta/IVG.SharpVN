namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Customers
    {
        [Key]
        public Guid CustomerID { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? CRMID { get; set; }

        public int? Customertype { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int Sex { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Address2 { get; set; }

        [StringLength(500)]
        public string Address3 { get; set; }

        [StringLength(50)]
        public string PostCode { get; set; }

        [StringLength(500)]
        public string TownOrCity { get; set; }

        public Guid? ProvinceID { get; set; }

        [StringLength(50)]
        public string AlternativeTelephoneNo { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? WardID { get; set; }

        [StringLength(20)]
        public string Mainphone { get; set; }

        [StringLength(20)]
        public string OfficePhone { get; set; }

        [StringLength(10)]
        public string Ext { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        [StringLength(20)]
        public string MobilePhone { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(150)]
        public string Token { get; set; }

        public bool? IsVeryfied { get; set; }

        public DateTime? VeryfiedOn { get; set; }

        public bool? IsDistributor { get; set; }

        public Guid? EWarrantyRoleId { get; set; }
    }
}
