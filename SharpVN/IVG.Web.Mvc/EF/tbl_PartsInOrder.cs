namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_PartsInOrder
    {
        public Guid ID { get; set; }

        public Guid OrderID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? OldID { get; set; }

        public int? ObjectCode { get; set; }

        public Guid? ObjectID { get; set; }

        public Guid? OldObjectID { get; set; }

        public int? OrderQty { get; set; }

        public int? ReadyQty { get; set; }

        public int? ApproveQty { get; set; }

        public double? UnitPrice { get; set; }

        public double? Total { get; set; }

        public int? ReceivedQty { get; set; }

        public int? TransferQty { get; set; }

        public string TransferSerial { get; set; }

        public string ReceivedSerial { get; set; }

        public int? Status { get; set; }

        public bool? FOC { get; set; }

        [StringLength(250)]
        public string Model { get; set; }

        [StringLength(50)]
        public string SerialModel { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }

        public int? State { get; set; }

        [StringLength(250)]
        public string ExtractSO { get; set; }
    }
}
