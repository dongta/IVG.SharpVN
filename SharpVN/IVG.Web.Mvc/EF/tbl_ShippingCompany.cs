namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ShippingCompany
    {
        [Key]
        public Guid CompanyID { get; set; }

        public Guid? CRMID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public Guid? WardID { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? ProvinceID { get; set; }

        public Guid? AreaID { get; set; }

        public int? Status { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Website { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [StringLength(20)]
        public string ContactPhone { get; set; }

        [StringLength(50)]
        public string ContactMail { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
