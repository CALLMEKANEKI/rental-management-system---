using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class hopdongViewModel
    {
        public string IDHopDong { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal TienCoc { get; set; }

        // Thuộc tính kết hợp người thuê
        public string TenNguoiThue { get; set; }
        public string TenPhong { get; set; }
    }
}
