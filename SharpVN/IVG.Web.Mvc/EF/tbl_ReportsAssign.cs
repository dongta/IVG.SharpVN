namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ReportsAssign
    {
        [Key]
        [Column(Order = 0)]
        public Guid ReportID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid Owner { get; set; }
    }
}
