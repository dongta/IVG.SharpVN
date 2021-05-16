namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_OrderTransaction
    {
        [Key]
        public Guid TransactionID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid OrderID { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        public int? TransferNumber { get; set; }

        public int? TotalTransfer { get; set; }

        public int? TotalReceived { get; set; }

        public int? Status { get; set; }

        public DateTime? Transferdate { get; set; }

        public Guid? CompanyID { get; set; }

        public DateTime? Receiveddate { get; set; }

        [StringLength(100)]
        public string ReceivedBy { get; set; }

        [StringLength(250)]
        public string ReferenceSO { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        public Guid? Owner { get; set; }
    }
}
