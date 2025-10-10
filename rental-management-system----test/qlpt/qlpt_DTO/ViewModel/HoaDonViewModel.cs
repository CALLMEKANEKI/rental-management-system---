using qlpt_DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.ViewModel
{
    public   class HoaDonViewModel:HoaDon
    {
        public string TenPhongHienThi { get; set; }

        // Thêm thuộc tính tổng hợp
        public decimal TongTienDien_HienThi { get; set; }
        public decimal ChiSo_Dien_Cu_HienThi {  get; set; }
        public decimal ChiSo_Dien_Moi_HienThi { get; set; }
        public decimal TongTienNuoc_HienThi { get; set; }
        public decimal ChiSo_Nuoc_Cu_HienThi { get; set; }
        public decimal ChiSo_Nuoc_Moi_HienThi { get; set; }
        public decimal TienPhong_HienThi { get; set; }
        public decimal TienDichVu_HienThi { get; set; }

        public decimal ThanhTien => TongTienDien_HienThi + TongTienNuoc_HienThi + TongTienLePhi_HienThi;
        public decimal TongTienLePhi_HienThi => TienPhong_HienThi + TienDichVu_HienThi;

    }
}
