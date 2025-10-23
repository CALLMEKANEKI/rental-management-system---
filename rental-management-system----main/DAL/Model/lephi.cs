namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lephi")]
    public partial class lephi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lephi()
        {
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [StringLength(10)]
        public string id_lephi { get; set; }

        [Required]
        [StringLength(100)]
        public string tenphong { get; set; }

        public decimal tien_dv { get; set; }

        public decimal thanh_tien_lephi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
    }
}
