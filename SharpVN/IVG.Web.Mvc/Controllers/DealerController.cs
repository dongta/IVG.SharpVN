using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using NLog;
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
        tbl_Users _user;
        Logger logger = LogManager.GetCurrentClassLogger();
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
        public JsonResult AddRequest(AddRequestInputDto i)
        {

            try
            {
                _user = Session["user"] as tbl_Users;

                tbl_Customers cus = new tbl_Customers
                {
                    Name = i.TenKhachHang,
                    HomePhone = i.SoDienthoaiKhac,
                    MobilePhone = i.SoDienthoai,
                    Email = i.Email,
                    Address = i.DiaChi,
                    ProvinceID = i.TinhTP,
                    DistrictID = i.QuanHuyen,
                    WardID = i.PhuongXa,
                    CustomerID = Guid.NewGuid(),
                    CreatedBy = _user.ID,
                    ModifiedBy = _user.ID,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                db.tbl_Customers.Add(cus);
                db.SaveChanges();

                tbl_CasesRequest r = new tbl_CasesRequest
                {
                    Code = Guid.NewGuid().ToString(),
                    ReceivedBy = i.NguoiTiepNhan,
                    RepairType = i.HinhThucBaoHanh,
                    ReferenceCode = i.MaThamChieu,
                    ReceivedDate = i.NgayTiepNhan,
                    Status = i.TrangThaiPhieu,
                    WarrantyStatus = i.TinhTrangBaoHanh,
                    TechnicalCheckedOn = i.NgayKtvKiemTra,
                    PurchaseDate = i.NgayMua,
                    MadeDate = i.NgaySanXuat,
                    EndDate = i.NgayHetBaoHanh,
                    ModelID = i.SanPham,
                    SerialNo = i.SerialNo,
                    DefectID = i.HienTuong,
                    Description = i.DienGiai,

                    CustomerID = cus.CustomerID,
                    PhoneNumber = i.SoDienthoai,
                    Address = i.DiaChi,
                    Email = i.Email,
                    ProvinceID = i.TinhTP,
                    DistrictID = i.QuanHuyen,
                    WardsID = i.PhuongXa,

                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    CreatedBy = _user.ID,
                    ModifiedBy = _user.ID
                };
                db.tbl_CasesRequest.Add(r);
                db.SaveChanges();
                return Json(r);
            }
            catch (Exception ex)
            {
                logger.Info(ex);
            }

            return Json(i);
        }
        public ActionResult ServiceDetail()
        {
            return View();
        }

    }
}