using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.API.Models
{
    public class Rootobject
    {
        public int      Draw { get; set; }
        public int      Start { get; set; }
        public int      Length { get; set; }
        public string FilterText { get; set; }
        public string OrderBy { get; set; }
        public string Ma { get; set; }
        public string MaThamChieu { get; set; }
        public string SoSerial { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string SanPham { get; set; }
        public string NgayTiepNhanTu { get; set; }
        public string NgayTiepNhanToi { get; set; }
        public string TrangThaiSuachua { get; set; }
        public string NgayTaoTu { get; set; }
        public string NgayTaoToi { get; set; }
    }

}