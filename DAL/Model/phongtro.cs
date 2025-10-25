namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("phongtro")]
    public partial class phongtro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public phongtro()
        {
            hopdongs = new HashSet<hopdong>();
            nguoi_thue = new HashSet<nguoi_thue>();
        }

        [Key]
        [StringLength(10)]
        public string id_phong { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string id_chutro { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string tenphong { get; set; }

        public decimal giaphong { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar")]
        public string tinhtrang { get; set; }

        public virtual chutro chutro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hopdong> hopdongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nguoi_thue> nguoi_thue { get; set; }
    }
}
