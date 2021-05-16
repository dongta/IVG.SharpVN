namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SerialLog
    {
        [Key]
        public Guid SerialLogID { get; set; }

        [StringLength(250)]
        public string SerialNo { get; set; }

        public Guid? SerialID { get; set; }

        public Guid? ModelID { get; set; }

        public int? CheckStatus { get; set; }

        public DateTime? CheckTime { get; set; }

        public int? ProcessStatus { get; set; }

        public DateTime? ProcessTime { get; set; }

        public Guid? ProcessBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
