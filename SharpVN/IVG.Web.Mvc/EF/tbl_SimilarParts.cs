namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SimilarParts
    {
        [Key]
        public Guid SimilarPartID { get; set; }

        public Guid MainPart { get; set; }

        public Guid SubPart { get; set; }

        public Guid? CRMID { get; set; }

        public int? SyncStatus { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
