using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class hoadonViewModel
    {
        public string IDHoaDon { get; set; }
        public DateTime NgayTao { get; set; } 
        public string TrangThai { get; set; }
        public string NoiDung { get; set; }
        public decimal ThanhTien { get; set; }

        // Thuộc tính kết hợp
        public string TenPhong { get; set; }
        public decimal ChiSoDien_Dau { get; set; }
        public decimal ChiSoDien_Cuoi { get; set; }
        public decimal ThanhTien_Dien { get; set; }

        public decimal ChiSoNuoc_Dau { get; set; }
        public decimal ChiSoNuoc_Cuoi { get; set; }
        public decimal ThanhTien_Nuoc { get; set; }

        public decimal Tien_dv { get; set; }

        public decimal Tien_Phong { get; set; }
    }
}
