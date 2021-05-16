namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_OptionSets
    {
        [Key]
        public int OptionSetID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
