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
            SCOptionSet sCOptionSet = new SCOptionSet();
            var trạngTháiSửaChữa = db.tbl_OptionSetValues
                            .Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.RepairStatus).ToList();
            var listValue = trạngTháiSửaChữa.Select(a => a.Value).ToList();
            var trangThaiPhieu = db.tbl_OptionSetValues
                .Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TransactionStatus && !listValue.Contains(a.Value)).ToList();

            sCOptionSet.TrangThaiSuaChua = trạngTháiSửaChữa.Union(trangThaiPhieu).OrderBy(a => a.Value)
                            .OrderBy(a => a.Value).Select(a => new DropdownItemDto
                            {
                                DisplayName = a.Text,
                                Id = a.Value.ToString(),
                                Name = a.Text,
                                LookupId = a.OptionSetID.ToString()
                            }).ToList();
            return View(sCOptionSet);
        }
        public ActionResult JobDetail()
        {
            return View();
        }
        public ActionResult UpdateJob(Guid id)
        {
            GetJobForStaffEditDto model = new GetJobForStaffEditDto();
            model.JobAndRequest = db.AllJobAndRequests.FirstOrDefault(a => a.CaseID == id);
            model.Tbl_Customers = db.tbl_Customers.FirstOrDefault(a => a.CustomerID == model.JobAndRequest.CustomerID);
            model.AllOptionSet = GetAllOptionSet(model.JobAndRequest?.ServiceCenterID, model.Tbl_Customers?.ProvinceID, model?.Tbl_Customers?.DistrictID);

            //var trạngTháiSửaChữa = db.tbl_OptionSetValues
            //                .Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.RepairStatus).ToList();
            //var listValue = trạngTháiSửaChữa.Select(a => a.Value).ToList();
            //var trangThaiPhieu = db.tbl_OptionSetValues
            //    .Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TransactionStatus && !listValue.Contains(a.Value)).ToList();

            //model.AllOptionSet.TrangThaiJobCombobox = trạngTháiSửaChữa.Union(trangThaiPhieu).OrderBy(a => a.Value)
            //                .OrderBy(a => a.Value).Select(a => new DropdownItemDto
            //                {
            //                    DisplayName = a.Text,
            //                    Id = a.Value.ToString(),
            //                    Name = a.Text,
            //                    LookupId = a.OptionSetID.ToString()
            //                }).ToList();

            return View(model);
        }

        public ActionResult PrintOrder()
        {
            return View();
        }
        public ActionResult Chat()
        {
            return View();
        }
        public PartialViewResult Chatbox()
        {
            return PartialView();
        }
        private AllOptionSet GetAllOptionSet(Guid? AscId = null, Guid? TinhThanhId = null, Guid? QuanHuyenId = null)
        {
            AllOptionSet optionObject = new AllOptionSet();
            //trung tâm sửa chữa
            optionObject.AscCombobox = db.tbl_ServiceCenters.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ServiceCenterID.ToString(),
                DisplayName = a.Code + " - " + a.Name,
            }).ToList();
            //Kỹ thuật viên
            optionObject.TechCombobox = AscId.HasValue ? db.tbl_TechnicalStaffs.Where(a => a.ServiceCenterID == AscId).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.TechnicalStaffID.ToString(),
                LookupId = a.ServiceCenterID.ToString(),
                DisplayName = a.Code + " - " + a.Name,
            }).ToList() : new List<DropdownItemDto>();
            optionObject.TrangThaiPhieuCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TransactionStatus).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            optionObject.ProductCombobox = db.tbl_Model.Where(a => a.Status == 1).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ModelID.ToString(),
                DisplayName = a.Code + " - " + a.Name + " | " + a.Description,
            }).ToList();
            optionObject.TrangThaiBaoHanhCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TrangThaiBaoHanh).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            optionObject.HinhThucBaoHanhCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.HinhThucBaoHanh).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            optionObject.HienTuongCombobox = db.tbl_DefectCodes.OrderBy(a => a.Code).Select(a => new DropdownItemDto
            {
                Id = a.DefectCodeID.ToString(),
                DisplayName = a.Description + " | " + a.DescriptionVN
            }).ToList();
            optionObject.CancelReasonCombobox = db.tbl_CancelReason.OrderBy(a => a.Reason).Select(a => new DropdownItemDto
            {
                Id = a.Id.ToString(),
                DisplayName = a.Reason
            }).ToList();
            optionObject.TinhThanhPhoCombobox = db.tbl_Provinces.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList();
            optionObject.QuanHuyenCombobox = TinhThanhId.HasValue ? db.tbl_Districts.Where(a => a.ProvinceID == TinhThanhId).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.DistrictID.ToString(),
                LookupId = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList() : new List<DropdownItemDto>();

            optionObject.PhuongXaCombobox = QuanHuyenId.HasValue ? db.tbl_Wards.Where(a => a.DistrictID == QuanHuyenId).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.WardID.ToString(),
                LookupId = a.DistrictID.ToString(),
                DisplayName = a.Name,
            }).ToList() : new List<DropdownItemDto>();
            var userCoookie = HttpContext.Request.Cookies["user"];
            if (userCoookie != null)
            {
                Guid uid = Guid.Parse(userCoookie["id"]);
                optionObject.UserCombobox = db.tbl_Users.OrderBy(a => a.DisplayName).Select(a => new DropdownItemDto
                {
                    Id = a.ID.ToString(),
                    DisplayName = a.DisplayName,
                    Selected = a.ID == uid ? true : false
                }).ToList();
            }
            optionObject.TrangThaiJobCombobox = db.v_RepairStatus.Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).OrderBy(a=>a.Id).ToList();
            return optionObject;
        }
    }
}