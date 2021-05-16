namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SMS
    {
        [Key]
        public Guid SMSId { get; set; }

        [StringLength(50)]
        public string From { get; set; }

        [StringLength(50)]
        public string To { get; set; }

        public int? Direction { get; set; }

        public int? Type { get; set; }

        public string Content { get; set; }

        public int? ProcessStatus { get; set; }

        public DateTime? ProcessTime { get; set; }

        public string ProcessMessage { get; set; }

        public Guid? Regarding { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
