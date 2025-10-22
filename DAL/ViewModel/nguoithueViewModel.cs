using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class nguoithueViewModel
    {
        public string IDNguoiThue { get; set; }
        public string HoTenNguoiThue { get; set; }
        public string SoDienThoai { get; set; }
        public string CCCD { get; set; }
        public string Email { get; set; }

        // Thuộc tính kết hợp từ PhongTro
        public string TenPhong { get; set; }
        public string IDPhong { get; set; }
    }
}

