using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class PhongTro
    {
        public int Id_Phong { get; set; } //PK
        public string TenPhong { get; set; }
        public decimal GiaPhong { get; set; }
        public string TinhTrang { get; set; }

        public int Id_ChuTro { get; set; } //FK
        public virtual ChuTro ChuTro { get; set; }
    }
}

