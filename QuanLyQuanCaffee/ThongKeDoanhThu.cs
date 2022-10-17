using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QuanLyQuanCaffee.Models;

namespace QuanLyQuanCaffee
{
    public partial class ThongKeDoanhThu : Form
    {
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        { 
            this.reportViewer1.RefreshReport();
            DBContentThongKe db = new DBContentThongKe();
            List<HOADON> listProduct = db.HOADONs.ToList();
            this.reportViewer1.LocalReport.ReportPath = "./ReportThongKe.rdlc";
            ReportDataSource reportDB = new ReportDataSource("DataSetThongKe", listProduct);
            this.reportViewer1.LocalReport.DataSources.Clear(); //clear this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.DataSources.Add(reportDB);
            //this.reportViewer1.LocalReport.DisplayName = " Bảng Báo Giá ";
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
