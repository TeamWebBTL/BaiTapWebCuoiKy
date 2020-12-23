namespace Ve.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETDONHANG")]
    public partial class CHITIETDONHANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_DDH { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Ve { get; set; }

        [StringLength(100)]
        public string ChiTietDDH { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual DONDATHANG DONDATHANG { get; set; }

        public virtual VE VE { get; set; }
    }
}
