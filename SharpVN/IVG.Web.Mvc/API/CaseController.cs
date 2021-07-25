using IVG.Web.Mvc.API.Models;
using IVG.Web.Mvc.Common;
using IVG.Web.Mvc.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IVG.Web.Mvc.API
{
    public class CaseController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpPost]
        public async Task<object> GetAll(GetRequestDto input)
        {
            try
            {
                //var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;

                var query = db.AllJobAndRequests.AsQueryable();
                var totalCount = query.Count();
                if (!string.IsNullOrEmpty(input?.FilterText))
                {
                    query = query.Where(a => a.CaseCode.Contains(input.FilterText)
                                          || a.SerialNo.Contains(input.FilterText)
                                          || a.ReferenceCode.Contains(input.FilterText)
                                          || a.CustomerName.Contains(input.FilterText)
                                          || a.CustomerPhone.Contains(input.FilterText)
                                          || a.CustomerOtherPhone.Contains(input.FilterText)
                                       );
                }
                if (!string.IsNullOrEmpty(input?.Ma))
                {
                    query = query.Where(a => a.CaseCode.Contains(input.Ma));
                }
                if (!string.IsNullOrEmpty(input?.MaThamChieu))
                {
                    query = query.Where(a => a.ReferenceCode.Contains(input.MaThamChieu));
                }
                if (!string.IsNullOrEmpty(input?.SanPham))
                {
                    query = query.Where(a => a.MaSanPham.Contains(input.SanPham));
                }
                if (!string.IsNullOrEmpty(input?.SoDienThoai))
                {
                    query = query.Where(a => a.CustomerPhone.Contains(input.SoDienThoai) || a.CustomerOtherPhone.Contains(input.SoDienThoai));
                }
                if (!string.IsNullOrEmpty(input?.SoSerial))
                {
                    query = query.Where(a => a.SerialNo.Contains(input.SoSerial));
                }
                if (!string.IsNullOrEmpty(input?.TenKhachHang))
                {
                    query = query.Where(a => a.CustomerName.Contains(input.TenKhachHang));
                }
                if (input.TrangThaiSuachua.HasValue)
                {
                    query = query.Where(a => a.RepairStatus == input.TrangThaiSuachua);
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
                    query = query.Where(a => a.ModifiedOn.Value >= input.NgayTiepNhanTu);
                }
                if (input.NgayTiepNhanToi.HasValue)
                {
                    query = query.Where(a => a.ModifiedOn.Value <= input.NgayTiepNhanToi);
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
                throw;
            }
        }
        // GET: api/Case
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Case/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Case
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Case/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Case/5
        public void Delete(int id)
        {
        }
    }
}
