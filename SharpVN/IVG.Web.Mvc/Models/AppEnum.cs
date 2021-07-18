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
            Administrator=0,
            Staff=1,
            Dealer=2
        }
        public enum OptionSetId
        {
            /// <summary>
            /// trạng thái phiếu yêu cầu | tình trạng sửa chữa| TransactionSataus
            /// </summary>
            TransactionStatus = 9,
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