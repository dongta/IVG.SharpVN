namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_NotFoundSerial
    {
        public Guid tbl_NotFoundSerialId { get; set; }

        [StringLength(250)]
        public string SerialNo { get; set; }

        public Guid? CreatedSerialNoId { get; set; }

        public Guid? CreatedProductId { get; set; }

        public int? CheckStatus { get; set; }

        public DateTime? CheckTime { get; set; }

        [StringLength(500)]
        public string Solution { get; set; }

        public int? ProcessStatus { get; set; }

        public DateTime? ProcessTime { get; set; }

        public Guid? ProcessBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
