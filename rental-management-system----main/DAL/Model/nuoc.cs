namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nuoc")]
    public partial class nuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nuoc()
        {
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [StringLength(10)]
        public string id_nuoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngay_tao { get; set; }

        public decimal chi_so_dau { get; set; }

        public decimal chi_so_cuoi { get; set; }

        public decimal thanh_tien_nuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
    }
}
