namespace IVG.Web.Mvc.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("DanhSachCaseRequest")]

    public class DanhSachCaseRequest
    {
        [Key]
        public Guid RequestId { get; set; }
        public string MaPhieu { get; set; }
        public string MaThamChieu { get; set; }
        public string TenKhachHang { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string SoDienThoaiKhac { get; set; }
        public string TenTrungTam { get; set; }
        public string TenKTV { get; set; }
        public string MaSanPham { get; set; }
        public string SoSerial { get; set; }
        public string MaLoi { get; set; }
        public string DienGiaiLoi { get; set; }
        public int? TrangThaiSuaChua { get; set; }
        public int? LoaiSuaChuaId { get; set; }
        public string CachSuaChua { get; set; }
        public string NgayDangKySuaChua { get; set; }
        public string NguoiTiepNhan { get; set; }
        public string CallCenterGhiChu { get; set; }
        public string ASCGhiChu { get; set; }
        public string ThangTT { get; set; }
        public string NgayKTVKiemTra { get; set; }
        public string ASCHoanThanhOn { get; set; }
        public string ASCHoanThanhBoi { get; set; }
    }
}
