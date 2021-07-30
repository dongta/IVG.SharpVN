using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class AllOptionSet
    {
       public List<DropdownItemDto> AscCombobox { get; set; }
       public List<DropdownItemDto> TechCombobox { get; set; }
       public List<DropdownItemDto> TrangThaiPhieuCombobox { get; set; }
       public List<DropdownItemDto> TrangThaiJobCombobox { get; set; }
        public List<DropdownItemDto> ProductCombobox { get; set; }
       public List<DropdownItemDto> TrangThaiBaoHanhCombobox { get; set; }
       public List<DropdownItemDto> HinhThucBaoHanhCombobox { get; set; }
       public List<DropdownItemDto> CancelReasonCombobox { get; set; }
        public List<DropdownItemDto> HienTuongCombobox { get; set; }
       public List<DropdownItemDto> TinhThanhPhoCombobox { get; set; }
       public List<DropdownItemDto> QuanHuyenCombobox { get; set; }
       public List<DropdownItemDto> PhuongXaCombobox { get; set; }
       public List<DropdownItemDto> UserCombobox { get; set; }

        public AllOptionSet()
        {
            AscCombobox = new List<DropdownItemDto>();
            TechCombobox = new List<DropdownItemDto>();
            TrangThaiPhieuCombobox = new List<DropdownItemDto>();
            ProductCombobox = new List<DropdownItemDto>();
            TrangThaiBaoHanhCombobox = new List<DropdownItemDto>();
            HinhThucBaoHanhCombobox = new List<DropdownItemDto>();
            HienTuongCombobox = new List<DropdownItemDto>();
            TinhThanhPhoCombobox = new List<DropdownItemDto>();
            QuanHuyenCombobox = new List<DropdownItemDto>();
            PhuongXaCombobox = new List<DropdownItemDto>();
            UserCombobox = new List<DropdownItemDto>();
        }
    }
}