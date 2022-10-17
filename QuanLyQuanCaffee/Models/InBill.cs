namespace QuanLyQuanCaffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InBill
    {
        [Key]
        public string TenMon { get; set; }

        public string GiaBan { get; set; }

        public string SoLuong { get; set; }
        public string ThanhTien { get; set; }

    }
}
