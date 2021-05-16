namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SI
    {
        [Key]
        public Guid SIID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public Guid? CustomerId { get; set; }

        public Guid? DistributorId { get; set; }

        [StringLength(250)]
        public string SerialNo { get; set; }

        public Guid? SerialId { get; set; }

        public Guid? ProductId { get; set; }

        public int? RegisterSource { get; set; }

        public Guid? WarrantyPolicyId { get; set; }

        public DateTime? WarrantyFrom { get; set; }

        public DateTime? WarrantyTo { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedByDistributorId { get; set; }

        public Guid? CreatedByCustomerId { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
