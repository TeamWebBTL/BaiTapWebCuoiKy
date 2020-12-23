namespace Ve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SUKIEN")]
    public partial class SUKIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUKIEN()
        {
            DANHGIAs = new HashSet<DANHGIA>();
        }

        public int ID { get; set; }

        [StringLength(30)]
        public string TieuDe { get; set; }

        [StringLength(30)]
        public string TacGia { get; set; }

        [StringLength(30)]
        public string TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySua { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [StringLength(30)]
        public string Anh { get; set; }

        [StringLength(30)]
        public string LoaiSuKien { get; set; }

        public int? ID_SinhVat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DANHGIA> DANHGIAs { get; set; }

        public virtual SINHVAT SINHVAT { get; set; }
    }
}
