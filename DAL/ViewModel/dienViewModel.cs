using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class dienViewModel
    {
        public string IdDien { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal ChiSo_Dau { get; set; }
        public decimal ChiSo_Cuoi { get; set; }
        public decimal TienDien { get; set; }
        public string TenPhong { get;set; }

        public string TrangThai { get; set; }
    }
}
