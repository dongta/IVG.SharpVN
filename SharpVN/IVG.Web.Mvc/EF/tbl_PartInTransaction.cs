namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PartInTransaction
    {
        public Guid ID { get; set; }

        public Guid TransactionID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid OrderID { get; set; }

        public Guid? Partinorder { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        public int? TransferQty { get; set; }

        public int? ReceivedQty { get; set; }

        public string TransferSerial { get; set; }

        public string ReceivedSerial { get; set; }

        public bool? FOC { get; set; }

        [StringLength(250)]
        public string Model { get; set; }

        [StringLength(50)]
        public string SerialModel { get; set; }

        public int? OrderQty { get; set; }

        public int? Status { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        public Guid? Owner { get; set; }

        public int? UpdateInventory { get; set; }

        public string Description { get; set; }
    }
}
