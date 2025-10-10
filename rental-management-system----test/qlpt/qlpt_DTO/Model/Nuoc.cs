using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlpt_DTO.Models
{
    public class Nuoc
    {
        public int Id_Nuoc { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal ChiSo_Dau { get; set; }
        public decimal ChiSo_Cuoi { get; set; }
        public decimal ThanhTien_Nuoc { get; set; }
    }
}
