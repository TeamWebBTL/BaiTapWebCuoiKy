namespace Ve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DANHGIA")]
    public partial class DANHGIA
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        [StringLength(50)]
        public string TacGia { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySua { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public int? ID_KhachHang { get; set; }

        public int? ID_SuKien { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual SUKIEN SUKIEN { get; set; }
    }
}
