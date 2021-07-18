using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class AddRequestInputDto
    {
        public string MaPhieu{ get; set; }
        public string NguoiTiepNhan { get; set; }
        [Required]
        public string DiaChi { get; set; }
        public string DienGiai { get; set; }
        public string Email { get; set; }
        public Guid? HienTuong { get; set; }
        public int? HinhThucBaoHanh { get; set; }
        public string MaThamChieu { get; set; }
        public DateTime? NgayHetBaoHanh { get; set; }
        public DateTime? NgayKtvKiemTra { get; set; }
        public DateTime? NgayMua { get; set; }
        public DateTime? NgaySanXuat { get; set; }
        public DateTime? NgayTiepNhan { get; set; }
        public Guid? SanPham { get; set; }
        public string SerialNo { get; set; }
        [Required]
        public string SoDienthoai { get; set; }
        public string SoDienthoaiKhac { get; set; }
        [Required]
        public string TenKhachHang { get; set; }
        public Guid? ASC { get; set; }
        public Guid? Technician { get; set; }
        public Guid? TinhTP { get; set; }
        public Guid? QuanHuyen { get; set; }
        public Guid? PhuongXa { get; set; }
        public Guid? TinhTrangBaoHanh { get; set; }
        public int? TrangThaiPhieu { get; set; }
    }
}