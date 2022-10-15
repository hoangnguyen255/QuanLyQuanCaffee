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
namespace QuanLyQuanCaffee
{
    public partial class frmCuaHang : Form
    {
        public frmCuaHang()
        {
            InitializeComponent();
        }


            //Sự kiện khi mà người dùng nhấn vào nút menu danh mục
            private void mnpDanhMuc_Click(object sender, EventArgs e)
            {
                //Hiện trang sản phẩm lên
                foreach (Form f in this.MdiChildren)
                {
                    if (f.Name == "frmSanPham")
                    {
                        f.Activate();
                        return;
                    }
                }
                frmSanPham sp = new frmSanPham();
                sp.MdiParent = this;
                sp.Show();
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "QuanLySanPham")
                {
                    f.Activate();
                    return;
                }
            }



        }
        List<string> list_detail;

        //Form cửa hàng khi load lên
        private void frmCuaHang_Load(object sender, EventArgs e)
            {
                mnpDanhMuc_Click(sender, e);
                MessageBox.Show("Xin chào User có ID là: " + frmDangNhap.ID_USER);
                list_detail = list_per(id_per(frmDangNhap.ID_USER));

        }



        //Đóng form cửa hàng và bật trang đăng nhập lên.




        //Sự kiện khi mà người dùng nhấn vào nút đăng xuất
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng xuất", "Trang cửa hàng cafe", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
                frmCuaHang fr = new frmCuaHang();
                fr.Hide();           
            }
        }
        //Sự kiện khi mà người dùng nhấn vào nút tạo tài khoản    
        private void tạoTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cần thoát trang cửa hàng để tạo tài khoản, bạn có muốn không?", "Trang cửa hàng cafe", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                frmTaoTaiKhoan frm = new frmTaoTaiKhoan();
                this.Hide();
                frm.ShowDialog();
            }
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanlynhanvien frm = new frmQuanlynhanvien();
            frm.ShowDialog();
            //checkper(code);
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLySanPham frm = new QuanLySanPham();
            frm.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M0KCUVC\BVSONXNB;Initial Catalog=QuanLyQuanCaffee;Integrated Security=True");
        private string id_per(string id_user)
        {
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_per_relationship WHERE id_user_rel ='" + id_user + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["suspended"].ToString() == "False")
                        {
                            id = dr["id_per_rel"].ToString();
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return id;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("id của nhóm quyền đó là:" + id_per(frmDangNhap.ID_USER));

            if (checkper("order") == true)
            {
                MessageBox.Show("có quyền");
            }
            else
            {
                MessageBox.Show("Bạn không có quyền");
            }
        }
        private List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_permission_detail WHERE id_per ='" + id_per + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        termsList.Add(dr["code_action"].ToString());
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return termsList;
        }

    
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    //quảnLýNhânViênToolStripMenuItem.Enabled = false;
                    //quảnLýSảnPhẩmToolStripMenuItem.Enabled = false;
                    check = true;
                }
            }
            return check;
        }

        

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (checkper("EDIT") == true)
        //    {
        //        MessageBox.Show("có quyền");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn không có quyền");
        //    }
        //}
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




