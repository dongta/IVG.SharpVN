namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Serial
    {
        [Key]
        public Guid SerialID { get; set; }

        [StringLength(250)]
        public string SerialNo { get; set; }

        public Guid? ModelID { get; set; }

        public DateTime? ProductDate { get; set; }

        public int? WarrantyMonths { get; set; }

        public DateTime? ActivateFrom { get; set; }

        public DateTime? ActivateTo { get; set; }

        public Guid? PolicyID { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
