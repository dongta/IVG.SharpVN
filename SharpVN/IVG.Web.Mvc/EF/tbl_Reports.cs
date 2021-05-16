namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Reports
    {
        [Key]
        public Guid ReportID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
