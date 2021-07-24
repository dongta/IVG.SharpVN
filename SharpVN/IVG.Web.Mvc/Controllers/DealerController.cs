using IVG.Web.Mvc.API.Models;
using IVG.Web.Mvc.Common;
using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using NLog;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
        // GET: Dealer
        public ActionResult Home()
        {
            return PartialView("Home");
        }
        public ActionResult ServiceRequest(GetRequestDto input)
        {
            //_user = (Session["user"] as tbl_Users) ?? db.tbl_Users.FirstOrDefault(a => a.UserName == User.Identity.Name);

            SCOptionSet sCOptionSet = new SCOptionSet();
            sCOptionSet.TrangThaiSuaChua = db.tbl_OptionSetValues
                            .Where(a => a.OptionSetID == (int)AppEnum.OptionSetId.TransactionStatus)
                            .OrderBy(a => a.Value).Select(a => new DropdownItemDto
                            {
                                DisplayName = a.Text,
                                Id = a.Value.ToString(),
                                Name = a.Text,
                                LookupId = a.OptionSetID.ToString()
                            }).ToList();
            return View(sCOptionSet);
        }
        public ActionResult AddRequest(Guid? id)
        {
            GetRequestForCreateOrEditDto createOrEditRequest = new GetRequestForCreateOrEditDto();
            createOrEditRequest.AllOptionSet = GetAllOptionSet();
            if (id.HasValue)
            {
                createOrEditRequest.Tbl_CasesRequest = db.tbl_CasesRequest.FirstOrDefault(a => a.CaseID == id);
                createOrEditRequest.Tbl_Customers = db.tbl_Customers.FirstOrDefault(a => a.CustomerID == createOrEditRequest.Tbl_CasesRequest.CustomerID);
            }
            return View(createOrEditRequest);
        }
        private AllOptionSet GetAllOptionSet(Guid? AscId = null, Guid? TinhThanhId = null, Guid? QuanHuyenId = null)
        {
            AllOptionSet optionObject = new AllOptionSet();
            //trung tâm sửa chữa
            optionObject.AscCombobox = db.tbl_ServiceCenters.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ServiceCenterID.ToString(),
                DisplayName = a.Name,
            }).ToList();
            //Kỹ thuật viên
            optionObject.TechCombobox = AscId.HasValue? db.tbl_TechnicalStaffs.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.TechnicalStaffID.ToString(),
                LookupId = a.ServiceCenterID.ToString(),
                DisplayName = a.Name,
            }).ToList():new List<DropdownItemDto>();
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
            optionObject.TinhThanhPhoCombobox = db.tbl_Provinces.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList();
            optionObject.QuanHuyenCombobox = TinhThanhId.HasValue? db.tbl_Districts.OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.DistrictID.ToString(),
                LookupId = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList():new List<DropdownItemDto>();

            optionObject.PhuongXaCombobox = QuanHuyenId.HasValue? db.tbl_Wards.OrderBy(a => a.Name).Select(a => new DropdownItemDto
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
            return optionObject;
        }
        [HttpPost]
        public JsonResult AddRequest(CreateOrEditCaseRequestDto input)
        {
            if (input.Id == Guid.Empty)
            {
                Create(input);
                return Json(input);
            }
            else
            {
                Update(input);
                return Json(input);
            }
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        NLogManager.Logger.Info("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            NLogManager.Logger.Info("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    NLogManager.Logger.Error(e);
            //}
        }

        public ActionResult ServiceDetail()
        {
            return View();
        }

        private CreateOrEditCaseRequestDto Create(CreateOrEditCaseRequestDto i)
        {
            try
            {
                _user = Session["user"] as tbl_Users;

                tbl_Customers cus = new tbl_Customers()

                {
                    Name = i.TenKhachHang,
                    Mainphone = i.SoDienthoai,
                    HomePhone = i.SoDienthoai,
                    MobilePhone = i.SoDienthoaiKhac,
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
                i.KhachHangId = cus.CustomerID;

                tbl_CasesRequest r = new tbl_CasesRequest
                {
                    CaseID = Guid.NewGuid(),
                    Code = i.MaPhieu = DateTime.Now.ToString("ddMMyyyyHHmmss"),//get from store cũ

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
                    CustomerName = i.TenKhachHang,
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
                i.Id = r.CaseID;
                return i;
            }
            catch (Exception ex)
            {
                NLogManager.Logger.Error(ex);
                throw;
            }
        }
        private CreateOrEditCaseRequestDto Update(CreateOrEditCaseRequestDto i)
        {
            try
            {
                _user = Session["user"] as tbl_Users;

                tbl_Customers cus = db.tbl_Customers.FirstOrDefault(a => a.CustomerID == i.KhachHangId);
                {
                    cus.Name = i.TenKhachHang;
                    cus.Mainphone = i.SoDienthoai;
                    cus.MobilePhone = i.SoDienthoaiKhac;
                    cus.Email = i.Email;
                    cus.Address = i.DiaChi;
                    cus.ProvinceID = i.TinhTP;
                    cus.DistrictID = i.QuanHuyen;
                    cus.WardID = i.PhuongXa;
                    cus.ModifiedBy = _user.ID;
                    cus.ModifiedOn = DateTime.Now;
                }
                db.SaveChanges();

                tbl_CasesRequest request = db.tbl_CasesRequest.FirstOrDefault(a => a.CaseID == i.Id);
                {
                    request.ReceivedBy = i.NguoiTiepNhan;
                    request.RepairType = i.HinhThucBaoHanh;
                    request.ReferenceCode = i.MaThamChieu;
                    request.ReceivedDate = i.NgayTiepNhan;
                    request.Status = i.TrangThaiPhieu;
                    request.WarrantyStatus = i.TinhTrangBaoHanh;
                    request.TechnicalCheckedOn = i.NgayKtvKiemTra;
                    request.PurchaseDate = i.NgayMua;
                    request.MadeDate = i.NgaySanXuat;
                    request.EndDate = i.NgayHetBaoHanh;
                    request.ModelID = i.SanPham;
                    request.SerialNo = i.SerialNo;
                    request.DefectID = i.HienTuong;
                    request.Description = i.DienGiai;

                    request.CustomerID = cus.CustomerID;
                    request.PhoneNumber = i.SoDienthoai;
                    request.CustomerName = i.TenKhachHang;
                    request.Address = i.DiaChi;
                    request.Email = i.Email;
                    request.ProvinceID = i.TinhTP;
                    request.DistrictID = i.QuanHuyen;
                    request.WardsID = i.PhuongXa;
                    
                    request.ModifiedOn = DateTime.Now;
                    request.ModifiedBy = _user.ID;
                }
                db.SaveChanges();
                return i;
            }
            catch (Exception ex)
            {
                NLogManager.Logger.Error(ex);
                throw;
            }
        }

    }
}