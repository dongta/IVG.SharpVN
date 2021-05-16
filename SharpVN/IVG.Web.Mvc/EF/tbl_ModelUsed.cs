namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_ModelUsed
    {
        public Guid ID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? ModelID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

        [StringLength(50)]
        public string WCardNo { get; set; }

        public DateTime? BoughtDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? SupplierID { get; set; }

        [StringLength(500)]
        public string PlaceOfBuy { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
