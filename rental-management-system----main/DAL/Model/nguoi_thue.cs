namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nguoi_thue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public nguoi_thue()
        {
            hopdongs = new HashSet<hopdong>();
            thanh_toan = new HashSet<thanh_toan>();
        }

        [Key]
        [StringLength(10)]
        public string id_nguoi_thue { get; set; }

        [Required]
        [StringLength(10)]
        public string id_phong { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(12)]
        public string cccd { get; set; }

        [StringLength(11)]
        public string sdt { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hopdong> hopdongs { get; set; }

        public virtual phongtro phongtro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<thanh_toan> thanh_toan { get; set; }
    }
}
