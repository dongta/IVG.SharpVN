namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AuditLogs
    {
        [Key]
        public Guid AuditLogID { get; set; }

        public Guid? AuditConfigurationID { get; set; }

        public Guid? ObjectID { get; set; }

        [StringLength(250)]
        public string EntityName { get; set; }

        [StringLength(250)]
        public string FieldName { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
