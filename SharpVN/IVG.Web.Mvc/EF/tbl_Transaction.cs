namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Transaction
    {
        public Guid ID { get; set; }

        public int? Type { get; set; }

        public int? Result { get; set; }

        public Guid? ModelID { get; set; }

        [StringLength(250)]
        public string Serial { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public string PurchasePlace { get; set; }

        public string CustomerSign { get; set; }

        [StringLength(500)]
        public string CustomerName { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        public Guid? ProvinceID { get; set; }

        public Guid? DistrictID { get; set; }

        public Guid? WardID { get; set; }

        public string Message { get; set; }

        public DateTime? TransactionDate { get; set; }
    }
}
