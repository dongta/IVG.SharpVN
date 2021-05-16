namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Users
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [StringLength(300)]
        public string Password { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string MobilePhone { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }

        public DateTime? LastLogOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? Owner { get; set; }

        public Guid? ServicecenterID { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsASC { get; set; }

        [StringLength(50)]
        public string Lang { get; set; }

        [StringLength(50)]
        public string SessionID { get; set; }

        public DateTime? LoginError { get; set; }

        public int? FailedNumber { get; set; }

        [StringLength(100)]
        public string EmailCredential { get; set; }

        [StringLength(500)]
        public string EmailPassWord { get; set; }

        [StringLength(250)]
        public string HostMail { get; set; }

        public bool? SendMail { get; set; }

        public DateTime? LastLock { get; set; }

        public int? LoginCount { get; set; }

        [StringLength(500)]
        public string Token { get; set; }

        public Guid? EWarrantyRoleId { get; set; }
        public virtual int? UserType { get; set; }
    }
}
