using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class HopDong
    {
        public int Id_HopDong { get; set; } //PK
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public decimal TienCoc { get; set; }

        // FK
        public int Id_Phong { get; set; }
        public int Id_ChuTro { get; set; }
        public int Id_NguoiThue { get; set; }

        public virtual PhongTro PhongTro { get; set; }
        public virtual ChuTro ChuTro { get; set; }
        public virtual NguoiThue NguoiThue { get; set; }
        
    }
}
