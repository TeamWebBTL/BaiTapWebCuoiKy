namespace Ve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVAT")]
    public partial class SINHVAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVAT()
        {
            SUKIENs = new HashSet<SUKIEN>();
        }

        public int ID { get; set; }

        [StringLength(30)]
        public string Ten { get; set; }

        [StringLength(30)]
        public string Loai { get; set; }

        [StringLength(30)]
        public string ViTri { get; set; }

        [StringLength(30)]
        public string MauSac { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [StringLength(100)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUKIEN> SUKIENs { get; set; }
    }
}
