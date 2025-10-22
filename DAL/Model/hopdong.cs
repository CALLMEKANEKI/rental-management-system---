namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hopdong")]
    public partial class hopdong
    {
        [Key]
        [StringLength(10)]
        public string id_hopdong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong { get; set; }

        [Required]
        [StringLength(10)]
        public string id_chutro { get; set; }

        [Required]
        [StringLength(10)]
        public string id_nguoi_thue { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_bat_dau { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_ket_thuc { get; set; }

        public decimal tien_coc { get; set; }

        public virtual chutro chutro { get; set; }

        public virtual nguoi_thue nguoi_thue { get; set; }

        public virtual phongtro phongtro { get; set; }
    }
}
