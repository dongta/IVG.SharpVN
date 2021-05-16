namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Entities
    {
        [Key]
        public Guid EntityID { get; set; }

        public int? ObjectCode { get; set; }

        [StringLength(250)]
        public string EntityName { get; set; }

        [StringLength(250)]
        public string ViewName { get; set; }

        [StringLength(250)]
        public string DisplayName { get; set; }

        [StringLength(250)]
        public string DisplayEnglish { get; set; }

        public bool? Status { get; set; }

        public string Details { get; set; }

        [StringLength(50)]
        public string Tab { get; set; }

        [StringLength(50)]
        public string SubTab { get; set; }

        [StringLength(250)]
        public string Urllink { get; set; }

        [StringLength(250)]
        public string RelationLink { get; set; }

        [StringLength(50)]
        public string icon { get; set; }

        public int? Order { get; set; }

        public bool? Create { get; set; }

        public bool? Read { get; set; }

        public bool? Write { get; set; }

        public bool? Delete { get; set; }

        public bool? Import { get; set; }

        public bool? Export { get; set; }

        public bool? Assign { get; set; }
    }
}
