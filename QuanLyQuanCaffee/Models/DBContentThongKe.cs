using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyQuanCaffee.Models
{
    public partial class DBContentThongKe : DbContext
    {
        public DBContentThongKe()
            : base("name=DBContentThongKe")
        {
        }

        public virtual DbSet<HOADON> HOADONs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
