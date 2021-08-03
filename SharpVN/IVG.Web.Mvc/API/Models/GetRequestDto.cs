using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class GetRequestDto:Paging
    {
        public string FilterText { get; set; }
        public string Ma { get; set; }
        public string RequestCode { get; set; }
        public string MaThamChieu { get; set; }
        public string SoSerial { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string SanPham { get; set; }
        public DateTime? NgayTiepNhanTu { get; set; }
        public DateTime? NgayTiepNhanToi { get; set; }
        public int? TrangThaiSuachua { get; set; }
        public DateTime? NgayTaoTu { get; set; }
        public DateTime? NgayTaoToi { get; set; }

        public GetRequestDto()
        {
            Start = 0;
            Length = 10;
        }
    }
}