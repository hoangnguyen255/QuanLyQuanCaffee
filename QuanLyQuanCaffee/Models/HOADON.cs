namespace QuanLyQuanCaffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        public int MaHD { get; set; }

        public DateTime? Ngay { get; set; }

        public int? TongTien { get; set; }
    }
}
