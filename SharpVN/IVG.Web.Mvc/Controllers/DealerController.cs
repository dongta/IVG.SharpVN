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
    public class DealerController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Dealer
        public ActionResult Home()
        {
            return PartialView("Home");
        }
        public ActionResult ServiceRequest()
        {
            return View();
        }
        public ActionResult AddRequest()
        {
            AddRequestDto model = new AddRequestDto();
            //trung tâm sửa chữa
            model.AscCombobox = db.tbl_ServiceCenters.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ServiceCenterID.ToString(),
                DisplayName = a.Name,
            }).ToList();
            //Kỹ thuật viên
            //model.TechCombobox = db.tbl_TechnicalStaffs.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            //{
            //    Id = a.TechnicalStaffID.ToString(),
            //    LookupId= a.ServiceCenterID.ToString(),
            //    DisplayName = a.Name,
            //}).ToList();
            model.TrangThaiPhieuCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TransactionStatus).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            model.ProductCombobox = db.tbl_Model.Where(a => a.Status == 1).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ModelID.ToString(),
                DisplayName = a.Code + " - " + a.Name + " | " + a.Description,
            }).ToList();
            model.TrangThaiBaoHanhCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TrangThaiBaoHanh).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            model.HinhThucBaoHanhCombobox = db.tbl_OptionSetValues.Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.HinhThucBaoHanh).OrderBy(a => a.Value).Select(a => new DropdownItemDto
            {
                Id = a.Value.ToString(),
                DisplayName = a.Text,
            }).ToList();
            model.HienTuongCombobox = db.tbl_DefectCodes.OrderBy(a => a.Code).Select(a => new DropdownItemDto
            {
                Id = a.DefectCodeID.ToString(),
                DisplayName = a.Description + " | " + a.DescriptionVN
            }).ToList();
            model.TinhThanhPhoCombobox = db.tbl_Provinces.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList();
            //model.QuanHuyenCombobox = db.tbl_Districts.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            //{
            //    Id = a.DistrictID.ToString(),
            //    LookupId = a.ProvinceID.ToString(),
            //    DisplayName = a.Name,
            //}).ToList();
            //model.PhuongXaCombobox = db.tbl_Wards.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            //{
            //    Id = a.WardID.ToString(),
            //    LookupId = a.DistrictID.ToString(),
            //    DisplayName = a.Name,
            //}).ToList();
            var userCoookie = HttpContext.Request.Cookies["user"];
            if (userCoookie != null)
            {
                Guid uid = Guid.Parse(userCoookie["id"]);
                model.UserCombobox = db.tbl_Users.OrderBy(a => a.DisplayName).Select(a => new DropdownItemDto
                {
                    Id = a.ID.ToString(),
                    DisplayName = a.DisplayName,
                    Selected = a.ID == uid ? true : false
                }).ToList();
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult AddRequest(AddRequestInputDto input)
        {
            var a = 1;
            input.MaPhieu = Guid.NewGuid().ToString();

            return Json(input);
        }
        public ActionResult ServiceDetail()
        {
            return View();
        }

    }
}