namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ColumnView
    {
        public Guid ID { get; set; }

        public Guid? EntityID { get; set; }

        public Guid? UserID { get; set; }

        [StringLength(250)]
        public string ViewName { get; set; }

        public string Column { get; set; }
    }
}
