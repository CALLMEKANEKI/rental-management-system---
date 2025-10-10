using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.ViewModel
{
    public class HopDongViewModel:HopDong
    {
        public string TenChuTroHienThi { get; set; }
        public string TenPhongHienThi { get; set; }
        public string TenNguoiThueHienThi { get; set; }
        public string CccdHienThi { get; set; }
        public string SdtHienThi { get; set; }
    }
}
