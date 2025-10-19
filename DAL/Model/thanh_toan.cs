namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class thanh_toan
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string id_nguoi_thue { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string id_hoadon { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_thanh_toan { get; set; }

        public virtual hoadon hoadon { get; set; }

        public virtual nguoi_thue nguoi_thue { get; set; }
    }
}
