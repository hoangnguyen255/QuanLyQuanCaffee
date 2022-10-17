using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QuanLyQuanCaffee
{
    public partial class frmCuaHang : Form
    {
        public frmCuaHang()
        {
            InitializeComponent();
        }    
        //Sự kiện khi mà người dùng nhấn vào nút đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất", "Trang cửa hàng cafe", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();                       
            }
        }
        //Sự kiện khi mà người dùng nhấn vào nút tạo tài khoản    
        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
                frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                this.Hide();
                frm.ShowDialog();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanlynhanvien frm = new frmQuanlynhanvien();
            this.Hide();
            frm.ShowDialog();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNguyenLieu frm = new QuanLyNguyenLieu();
            this.Hide();
            frm.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            this.Hide();
            frm.ShowDialog();
        }

        public frmCuaHang(string x) : this()
        {
            if (int.Parse(x) == 2)
            {
                thốngKêToolStripMenuItem.Enabled = false;
                quảnLýToolStripMenuItem.Enabled = false;
                tạoTàiKhoảnToolStripMenuItem.Enabled = false;
            }
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu thongke = new ThongKeDoanhThu();
            thongke.ShowDialog();   
        }

        private void frmCuaHang_Load(object sender, EventArgs e)
        {
            //mnpDanhMuc_Click(sender, e);
            //list_detail = list_per(id_per(frmDangNhap.ID_USER));
            //frmSanPham sp = new frmSanPham();
            //sp.ShowDialog();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.facebook.com/profile.php?id=100011308278932"; // URL cần được mở trên trình duyệt.
            Process.Start(url);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.facebook.com/profile.php?id=100033557679930"; // URL cần được mở trên trình duyệt.
            Process.Start(url);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.facebook.com/profile.php?id=100051811266473"; // URL cần được mở trên trình duyệt.
            Process.Start(url);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://www.facebook.com/profile.php?id=100010340624152"; // URL cần được mở trên trình duyệt.
            Process.Start(url);
        }
    }
}
/****** Object:  Table [dbo].[tbl_permission]    Script Date: 10/15/2022 1:01:48 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[tbl_permission] (

//    [id_per][int] NOT NULL,

//    [name_per] [nvarchar] (50) NULL,
//	[description][nvarchar] (50) NULL,
// CONSTRAINT[PK_permission] PRIMARY KEY CLUSTERED 
//(

//    [id_per] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO



/****** Object:  Table [dbo].[tbl_user]    Script Date: 10/15/2022 1:03:17 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[tbl_user] (

//    [id_user][int] NOT NULL,

//    [name_user] [nvarchar] (50) NOT NULL,

//    [user_name] [nvarchar] (50) NOT NULL,

//    [pass] [nvarchar] (50) NULL,
// CONSTRAINT[PK_user] PRIMARY KEY CLUSTERED 
//(

//    [id_user] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO


///****** Object:  Table [dbo].[tbl_permission_detail]    Script Date: 10/15/2022 1:01:58 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[tbl_permission_detail] (

//    [id_pd][int] NOT NULL,

//    [name_action] [nvarchar] (50) NULL,
//	[code_action][varchar] (50) NULL,
//	[id_per][int] NULL,
// CONSTRAINT[PK_permission_detail] PRIMARY KEY CLUSTERED 
//(

//    [id_pd] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO

//ALTER TABLE [dbo].[tbl_permission_detail] WITH CHECK ADD  CONSTRAINT [FK_permission_detail_permission] FOREIGN KEY([id_per])
//REFERENCES[dbo].[tbl_permission]([id_per])
//GO

//ALTER TABLE [dbo].[tbl_permission_detail] CHECK CONSTRAINT[FK_permission_detail_permission]
//GO


///****** Object:  Table [dbo].[tbl_permission]    Script Date: 10/15/2022 1:01:48 AM ******/
//SET ANSI_NULLS ON
//GO

//SET QUOTED_IDENTIFIER ON
//GO

//CREATE TABLE [dbo].[tbl_permission] (

//    [id_per][int] NOT NULL,

//    [name_per] [nvarchar] (50) NULL,
//	[description][nvarchar] (50) NULL,
// CONSTRAINT[PK_permission] PRIMARY KEY CLUSTERED 
//(

//    [id_per] ASC
//)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
//) ON[PRIMARY]
//GO




