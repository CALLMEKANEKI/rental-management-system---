using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class NguoiThue
    {
            public int Id_NguoiThue { get; set; } //PK
            public string HoTen { get; set; }
            public string Cccd { get; set; } 
            public string Sdt { get; set; }
            public string Email { get; set; }
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public int Id_Phong { get; set; } //FK

            public virtual PhongTro PhongTro { get; set; }
    }
}
