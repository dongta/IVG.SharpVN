using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    public class ComboboxController : ApiController
    {
        AppDbContext db = new AppDbContext();

        public List<DropdownItemDto> GetQuanHuyenComboxByTinhThanhId(Guid id)
        {
            return db.tbl_Districts.Where(a => a.ProvinceID == id).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.DistrictID.ToString(),
                LookupId = a.ProvinceID.ToString(),
                DisplayName = a.Name,
            }).ToList(); ;
        }

        public List<DropdownItemDto> GetPhuongXaComboxByQuanHuyenId(Guid id)
        {
            return db.tbl_Wards.Where(a => a.DistrictID == id).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.WardID.ToString(),
                LookupId = a.DistrictID.ToString(),
                DisplayName = a.Name,
            }).ToList();
        }
        public List<DropdownItemDto> GetKyThuatVienByTrungTamId(Guid id)
        {
            return db.tbl_TechnicalStaffs.Where(a => a.ServiceCenterID == id).OrderBy(a => a.Name).Select(a => new DropdownItemDto
            {
                Id = a.TechnicalStaffID.ToString(),
                LookupId = a.ServiceCenterID.ToString(),
                DisplayName = a.Name + (a.MobilePhone.Length>0?" | "+a.MobilePhone:""),
            }).ToList();
        }
    }
}
