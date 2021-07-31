using System;
using System.Collections.Generic;

namespace IVG.Web.Mvc.API.Models
{
    public  class CreateOrEditUserInput
    {
        public Guid ID { get; set; }

        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string MobilePhone { get; set; }

        public string Description { get; set; }

        public bool? Active { get; set; }

        public string ActiveName { get; set; }

        public DateTime? LastLogOn { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public Guid? Owner { get; set; }

        public Guid? ServicecenterID { get; set; }

        public string AscName { get; set; }

        public bool? IsAdmin { get; set; }

        public bool? IsASC { get; set; }

        public string Lang { get; set; }

        public string SessionID { get; set; }

        public DateTime? LoginError { get; set; }

        public int? FailedNumber { get; set; }

        public string EmailCredential { get; set; }

        public string EmailPassWord { get; set; }

        public string HostMail { get; set; }

        public bool? SendMail { get; set; }

        public DateTime? LastLock { get; set; }

        public int? LoginCount { get; set; }

        public string Token { get; set; }

        public Guid? EWarrantyRoleId { get; set; }
        public List<string> ListRole { get; set; }
    }
}
