namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("chutro")]
    public partial class chutro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public chutro()
        {
            hopdongs = new HashSet<hopdong>();
            phongtroes = new HashSet<phongtro>();
        }

        [Key]
        [StringLength(10)]
        public string id_chutro { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(10)]
        public string sdt { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(255)]
        public string diachi { get; set; }

        [StringLength(50)]
        public string taikhoan { get; set; }

        [Required]
        [StringLength(20)]
        public string matkhau { get; set; }

        [StringLength(255)]
        public string avatar_url { get; set; }

        [StringLength(255)]
        public string anh_cccd_truoc_url { get; set; }

        [StringLength(255)]
        public string anh_cccd_sau_url { get; set; }

        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hopdong> hopdongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<phongtro> phongtroes { get; set; }
    }
}
