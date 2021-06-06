using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Staff
        public ActionResult Home()
        {
            return View("Home");
        }
        public ActionResult SVC()
        {
            return View();
        }
        public ActionResult CRM()
        {
            return View();
        }
        public ActionResult ServiceLog()
        {
            FilterServiceLogItemDto dto = new FilterServiceLogItemDto();
            //dto.tbl_EscalationDicision = db.tbl_EscalationDicision.OrderBy(a => a.Name).ToList();
            //dto.tbl_TransactionChannel = db.tbl_TransactionChannel.OrderBy(a => a.Name).ToList();
            //dto.tbl_Provinces = db.tbl_Provinces.OrderBy(a => a.Name).ToList();
            //dto.tbl_EscalateTo= db.tbl_EscalateTo.OrderBy(a => a.Name).ToList();
            //dto.tbl_QualityAssuranceChecking = db.tbl_QualityAssuranceChecking.OrderBy(a => a.Name).ToList();
            //dto.tbl_TypeOfInquiry = db.tbl_TypeOfInquiry.OrderBy(a => a.Name).ToList();
            //dto.tbl_ProductType = db.tbl_ProductType.OrderBy(a => a.Name).ToList();
            //dto.tbl_TransactionStatus = db.tbl_TransactionStatus.OrderBy(a => a.Name).ToList();

            dto.SortBy = new List<SortBy>();
            dto.SortBy.Add(new SortBy { Value = 1, Text = "Reference No. (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 2, Text = "Reference No. (Z-A)" });

            dto.SortBy.Add(new SortBy { Value = 3, Text = "Report ID (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 4, Text = "Report ID (Z-A)" });

            dto.SortBy.Add(new SortBy { Value = 5, Text = "Customer Name (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 6, Text = "Customer Name (Z-A)" });

            dto.SortBy.Add(new SortBy { Value = 7, Text = "Customer telephone No. (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 8, Text = "Customer telephone No. (Z-A)" });

            dto.SortBy.Add(new SortBy { Value = 9, Text = "Request from (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 10, Text = "Request from (Z-A)" });

            dto.SortBy.Add(new SortBy { Value = 11, Text = "Request to (A-Z)" });
            dto.SortBy.Add(new SortBy { Value = 12, Text = "Request to (Z-A)" });
            return View(dto);
        }
        public ActionResult JobDetail()
        {
            return View();
        }
        public ActionResult PrintOrder()
        {
            return View();
        }
    }
}