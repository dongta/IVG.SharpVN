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

namespace IVG.Web.Mvc.API
{
    public class CaseRequestController : ApiController
    {
        AppDbContext db = new AppDbContext();

        [HttpPost]
        public async Task<object> GetRequest(GetRequestDto input)
        {
            var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;
           
            var query = db.DanhSachCaseRequest.Where(a=>a.CreatedBy==userId);
            var totalCount = query.Count();
            if (!string.IsNullOrEmpty(input?.filterText))
            {
                query = query.Where(a => a.MaPhieu.Contains(input.filterText)
                                      || a.SoSerial.Contains(input.filterText)
                                      || a.TenKhachHang.Contains(input.filterText)
                                      || a.SoDienThoai.Contains(input.filterText)
                                      || a.MaThamChieu.Contains(input.filterText)
                                      || a.SoDienThoaiKhac.Contains(input.filterText)
                                      || a.MaSanPham.Contains(input.filterText));

            }
            var filterCount = query.Count();
            query = query.OrderByDescending(a => a.CreatedOn);
            query = query.Skip(input.Start).Take(input.Length);
            var data = query.ToList();
            return new PagedResultDto(draw: input.Draw, totalRecords: totalCount, filteredRecords: filterCount, data: data);
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
