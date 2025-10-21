namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            thanh_toan = new HashSet<thanh_toan>();
        }

        [Key]
        [StringLength(10)]
        public string id_hoadon { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_tao { get; set; }

        [Required]
        [StringLength(50)]
        public string trang_thai { get; set; }

        [StringLength(255)]
        public string noi_dung { get; set; }

        [StringLength(10)]
        public string id_dien { get; set; }

        [StringLength(10)]
        public string id_lephi { get; set; }

        [StringLength(10)]
        public string id_nuoc { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong { get; set; }

        public decimal thanh_tien { get; set; }

        public virtual phongtro phongtro { get; set; }

        public virtual dien dien { get; set; }

        public virtual lephi lephi { get; set; }

        public virtual nuoc nuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<thanh_toan> thanh_toan { get; set; }
    }
}
