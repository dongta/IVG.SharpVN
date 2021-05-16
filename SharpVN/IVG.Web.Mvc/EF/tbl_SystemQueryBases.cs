namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SystemQueryBases
    {
        [Key]
        public int SystemQueryBaseID { get; set; }

        public int? Object { get; set; }

        public Guid? EntityID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Query { get; set; }

        public int? Order { get; set; }

        public bool? Status { get; set; }
    }
}
