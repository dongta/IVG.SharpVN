namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PageNews
    {
        [Key]
        public Guid NewsID { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public string NewsContent { get; set; }
    }
}
