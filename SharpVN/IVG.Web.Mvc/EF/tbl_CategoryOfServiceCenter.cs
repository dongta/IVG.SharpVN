namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CategoryOfServiceCenter
    {
        [Key]
        [Column(Order = 0)]
        public Guid ServiceCenterID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid CategoryID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
