namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SerialNo
    {
        [Key]
        public Guid SerialNoId { get; set; }

        [StringLength(250)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public Guid? ProductId { get; set; }

        public DateTime? NgaySanXuat { get; set; }

        public int? SoThangBaoHanh { get; set; }

        public DateTime? HanKichHoatBaoHanh { get; set; }

        public DateTime? HanBaoHanhToiDaToi { get; set; }

        public Guid? WarrantyPolicyId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? ModifiedBy { get; set; }
    }
}
