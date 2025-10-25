using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class thanhToanViewModel
    {

        public string MaHD { get; set; }

        public DateTime NgayTao { get; set; }

        public string NoiDung { get; set; }

        public decimal LePhi { get; set; }

        public decimal TienDien { get; set; }

        public decimal TienNuoc { get; set; }

        public decimal ThanhTien { get; set; }

        public DateTime NgayThanhToan { get; set; }

        public string TenNguoiThanhToan { get; set; }

        public string TenPhong { get; set; }

    }
}

