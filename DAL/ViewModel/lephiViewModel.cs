using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModel
{
    public class lephiViewModel
    {
        public string IdLePhi { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TienPhong { get; set; }
        public decimal TienDV { get; set; }
        public decimal TienLePhi { get; set; }
        public string TenPhong { get;set; }

        public string TrangThai { get; set; }
    }
}
