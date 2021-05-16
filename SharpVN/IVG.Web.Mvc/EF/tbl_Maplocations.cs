namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Maplocations
    {
        [Key]
        public Guid MaplocationID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? ServiceCenterID { get; set; }

        public Guid? WardID { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? ProvinceID { get; set; }

        [StringLength(100)]
        public string Distance { get; set; }

        public double? Cost { get; set; }

        public Guid? CategoryID { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
