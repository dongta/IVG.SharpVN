using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVG.Web.Mvc.Models
{
    public class AppEnum
    {
        public enum Role
        {
            Administrator=1000,
            Staff=1,
            Dealer=2
        }
        public enum TrangThaiPhieuYeuCau
        {
            ChuaXuLy=1,
            DaChuyenThanhJob=2,
            DaHuy =3,
            DaHoanThanh=6,
        }
        public enum RepairStatus
        {
            ChuaXuLy = 1,
            DaChuyenThanhJobOrChoASCXacNhan = 2,
            DaHuy = 3,
            AscDangXuLy = 4,
            HoanThanhBoiASC =5,
            HoanThanhBoiSVN=6,
            ChuyenLenCapTrenGiaiQuyet =8,
            KhongChapNhanPhieu =9,
            HoldingBoiSVN =10
        }
        public enum OptionSetId
        {
            /// <summary>
            /// trạng thái phiếu yêu cầu | tình trạng sửa chữa| TransactionSataus
            /// dữ liệu này áp dụng cho phiếu yêu cầu
            /// </summary>
            TransactionStatus = 9,
            /// <summary>
            /// trạng thái sửa chữa -> trên 1 job 
            /// </summary>
            RepairStatus = 10,
            /// <summary>
            /// Tình trạng sản phẩm còn bảo hành | hết BH
            /// </summary>
            TrangThaiBaoHanh = 11,
            /// <summary>
            /// Nơi thực hiện bảo hành
            /// </summary>
            HinhThucBaoHanh =2,//Nơi thực hiện bảo hành
        }
    }
}