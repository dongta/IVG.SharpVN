namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_SystemPermissions
    {
        [Key]
        [Column(Order = 0)]
        public Guid RoleID { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid EntityID { get; set; }

        public int? Create { get; set; }

        public int? Read { get; set; }

        public int? Write { get; set; }

        public int? Delete { get; set; }

        public int? Import { get; set; }

        public int? Export { get; set; }

        public int? Assign { get; set; }
    }
}
