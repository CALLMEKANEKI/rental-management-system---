using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class LePhi
    {
        public int Id_LePhi { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TienPhong { get; set; }
        public decimal TienDv { get; set; }
        
        public decimal ThanhTien_LePhi
        {
            get { return TienPhong + TienDv; }
        }
    }
}
