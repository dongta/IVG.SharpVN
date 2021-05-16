namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Attribute
    {
        [Key]
        public Guid AttributeID { get; set; }

        public Guid EntityID { get; set; }

        [Required]
        [StringLength(250)]
        public string AttributeName { get; set; }

        [Required]
        [StringLength(250)]
        public string DisplayName { get; set; }

        [StringLength(250)]
        public string DisplayNameEn { get; set; }

        public int? Width { get; set; }

        public bool? Visible { get; set; }

        [StringLength(250)]
        public string HyperLink { get; set; }

        public bool? KeyColumn { get; set; }

        public bool? AuditLogs { get; set; }
    }
}
