using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class ThanhToan
    {
        public int Id_HoaDon { get; set; }
        public int Id_NguoiThue { get; set; }
        public virtual HoaDon HoaDon { get; set; }
        public virtual NguoiThue NguoiThue { get; set; }
        public DateTime NgayThanhToan { get; set; }
    }
}
