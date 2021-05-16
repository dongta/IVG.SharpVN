namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Model
    {
        [Key]
        public Guid ModelID { get; set; }

        public Guid? CRMID { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? CategoryID { get; set; }

        public int? WarrantyTime { get; set; }

        public int? WarrantyType { get; set; }

        public int? Status { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
