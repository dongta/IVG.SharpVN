namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Files
    {
        public Guid ID { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Stream { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Extension { get; set; }
    }
}
