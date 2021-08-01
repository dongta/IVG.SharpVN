using IVG.Web.Mvc.API.Models;
using IVG.Web.Mvc.EF;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System;
using IVG.Web.Mvc.Common;

namespace IVG.Web.Mvc.API
{
    public class CaseRequestController : ApiController
    {
        AppDbContext db = new AppDbContext();

        [HttpPost]
        public async Task<object> GetRequest(GetRequestDto input)
        {
            try
            {
                var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;

                var query = db.DanhSachCaseRequest.Where(a => a.CreatedBy == userId);
                var totalCount = query.Count();
                if (!string.IsNullOrEmpty(input?.FilterText))
                {
                    query = query.Where(a => a.MaPhieu.Contains(input.FilterText)
                                          || a.SoSerial.Contains(input.FilterText)
                                          || a.TenKhachHang.Contains(input.FilterText)
                                          || a.SoDienThoai.Contains(input.FilterText)
                                          || a.MaThamChieu.Contains(input.FilterText)
                                          || a.SoDienThoaiKhac.Contains(input.FilterText)
                                          || a.MaSanPham.Contains(input.FilterText));
                }
                if (!string.IsNullOrEmpty(input?.Ma))
                {
                    query = query.Where(a => a.MaPhieu.Contains(input.Ma));
                }
                if (!string.IsNullOrEmpty(input?.MaThamChieu))
                {
                    query = query.Where(a => a.MaThamChieu.Contains(input.MaThamChieu));
                }
                if (!string.IsNullOrEmpty(input?.SanPham))
                {
                    query = query.Where(a => a.MaSanPham.Contains(input.SanPham));
                }
                if (!string.IsNullOrEmpty(input?.SoDienThoai))
                {
                    query = query.Where(a => a.SoDienThoai.Contains(input.SoDienThoai) || a.SoDienThoaiKhac.Contains(input.SoDienThoai));
                }
                if (!string.IsNullOrEmpty(input?.SoSerial))
                {
                    query = query.Where(a => a.SoSerial.Contains(input.SoSerial));
                }
                if (!string.IsNullOrEmpty(input?.TenKhachHang))
                {
                    query = query.Where(a => a.TenKhachHang.Contains(input.TenKhachHang));
                }
                if (input.TrangThaiSuachua.HasValue)
                {
                    query = query.Where(a => a.TrangThaiSuaChua == input.TrangThaiSuachua);
                }
                if (input.NgayTaoTu.HasValue)
                {
                    query = query.Where(a => a.CreatedOn.Value >= input.NgayTaoTu);
                }
                if (input.NgayTaoToi.HasValue)
                {
                    query = query.Where(a => a.CreatedOn.Value <= input.NgayTaoToi);
                }
                if (input.NgayTiepNhanTu.HasValue)
                {
                    query = query.Where(a => a.NgayTiepNhan.Value >= input.NgayTiepNhanTu);
                }
                if (input.NgayTiepNhanToi.HasValue)
                {
                    query = query.Where(a => a.NgayTiepNhan.Value <= input.NgayTiepNhanToi);
                }

                var filterCount = query.Count();
                query = query.OrderByDescending(a => a.CreatedOn);
                query = query.Skip(input.Start).Take(input.Length);
                var data = query.ToList();
                return new PagedResultDto(draw: input.Draw, totalRecords: totalCount, filteredRecords: filterCount, data: data);
            }
            catch (Exception ex)
            {
                NLogManager.Logger.Error(ex);
                throw ;
            }
        }
        // GET: api/CaseRequest
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CaseRequest/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CaseRequest
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CaseRequest/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/CaseRequest/5
        public void Delete(int id)
        {
        }
    }
}
