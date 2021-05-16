namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_AutoNumbers
    {
        [Key]
        [Column(Order = 0)]
        public Guid ServiceCenterID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ObjectCode { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public int? Number { get; set; }
    }
}
