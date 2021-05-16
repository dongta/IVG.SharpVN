namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SerialActivate
    {
        [Key]
        public Guid SerialActivateID { get; set; }

        [StringLength(50)]
        public string SerialNo { get; set; }

        public Guid? CustomerID { get; set; }

        public Guid? DistributorID { get; set; }

        public Guid? SerialID { get; set; }

        public Guid? ModelID { get; set; }

        public int? RegisterSource { get; set; }

        public Guid? PolicyID { get; set; }

        public DateTime? WarrantyFrom { get; set; }

        public DateTime? WarrantyTo { get; set; }

        public string Description { get; set; }

        public string Note { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedByDistributorID { get; set; }

        public Guid? CreatedByCustomerID { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        [StringLength(100)]
        public string PlaceOfPurchase { get; set; }

        [StringLength(100)]
        public string WarrantyAddress { get; set; }
    }
}
