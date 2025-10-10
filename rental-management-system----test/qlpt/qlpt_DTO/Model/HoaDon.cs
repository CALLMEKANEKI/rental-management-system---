using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class HoaDon
    {
        public int Id_HoaDon { get; set; } //PK
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
        public string NoiDung { get; set; }
        public decimal ThanhTien { get; set; }

        //FK
        public int Id_LePhi { get; set; }
        public int Id_Dien { get; set; }
        public int Id_Nuoc { get; set; }
        public int Id_Phong { get; set; }

        public virtual LePhi LePhi { get; set; }
        public virtual Dien Dien { get; set; }
        public virtual Nuoc Nuoc { get; set; }
        public virtual PhongTro PhongTro { get; set; }
    }
}
