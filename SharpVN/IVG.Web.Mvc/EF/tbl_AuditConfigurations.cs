namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AuditConfigurations
    {
        [Key]
        public Guid AuditConfigurationID { get; set; }

        [StringLength(250)]
        public string EntityName { get; set; }

        [StringLength(250)]
        public string DisplayName { get; set; }

        public Guid? EntityID { get; set; }

        [StringLength(250)]
        public string FieldName { get; set; }

        [StringLength(250)]
        public string FieldDisplay { get; set; }

        public string Description { get; set; }
    }
}
