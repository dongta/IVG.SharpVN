namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ImportResult
    {
        public Guid ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(250)]
        public string UrlFile { get; set; }

        public int? Total { get; set; }

        public int? Failure { get; set; }

        public int? Success { get; set; }

        public int? Duplicate { get; set; }

        public int? StatusCode { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
