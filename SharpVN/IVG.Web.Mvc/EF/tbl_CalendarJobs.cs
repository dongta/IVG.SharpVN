namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_CalendarJobs
    {
        public Guid ID { get; set; }

        public Guid? CRMID { get; set; }

        public Guid? CaseID { get; set; }

        public Guid? TechnicalStaffID { get; set; }

        public Guid? AssignBy { get; set; }

        public DateTime? AssignTime { get; set; }

        public DateTime? ScheduleStart { get; set; }

        public DateTime? ScheduleEnd { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompleteDate { get; set; }

        public int? Status { get; set; }

        public string Description { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int? SyncStatus { get; set; }
    }
}
