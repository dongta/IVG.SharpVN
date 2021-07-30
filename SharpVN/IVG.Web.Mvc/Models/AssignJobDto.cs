using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class AssignJobDto
    {
        public Guid Id { get; set; }
        public Guid ServiceCenterId { get; set; }
    }
    public class CancelJobDto
    {
        public Guid Id { get; set; }
        public Guid CancelReasonId { get; set; }
    }
}