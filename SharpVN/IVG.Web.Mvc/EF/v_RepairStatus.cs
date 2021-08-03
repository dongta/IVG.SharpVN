namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class v_RepairStatus
    {
        public int OptionSetID { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Value { get; set; }

        [StringLength(250)]
        public string Text { get; set; }

        public string Description { get; set; }
    }
}
